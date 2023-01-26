using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using App.Auth;
using Core.Entities.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace App.Services.impl;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public AuthenticationService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
        IConfiguration configuration)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<LoginResponse> Login(LoginModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));

            }

            var token = CreateToken(authClaims);
            var refreshToken = GenerateRefreshToken();

            _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

            await _userManager.UpdateAsync(user);
            return new LoginResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };

        }

        return new LoginResponse();
    }

    public async Task<Response> Register(RegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
        {
            // Return statuscode 500, new Response { Status = "Error", Message = "User already exists!" });
            return new Response()
            {
                Status = "Error",
                Message = "User already exists!"
            };
        }

        ApplicationUser user = new()
        {
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            //return status code 500, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." }
            return new Response()
            {
                Status = "Error",
                Message = "User creation failed! Please check user details and try again."
            };
        }
        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
        {
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
        }
        if (await _roleManager.RoleExistsAsync(UserRoles.User))
        {
            await _userManager.AddToRoleAsync(user, UserRoles.User);
        }
        

        return new Response { Status = "Success", Message = "User Created successfully!" };
    }

    public async Task<Response> RegisterAdmin(RegisterModel model)
    {


        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
            return new Response()
            {
                Status = "Error",
                Message = "User already exists!"
            };
        
        ApplicationUser user = new()
        {
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return new Response()
            {
                Status = "Error",
                Message = "User creation failed! Please check user details and try again."
            };
        
        if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
        {
            await _userManager.AddToRoleAsync(user, UserRoles.Admin);
        }
        if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
        {
            await _userManager.AddToRoleAsync(user, UserRoles.User);
        }
        return new Response
        {
            Status = "Success",
            Message = "User created successfully"
        };

    }

    public async Task<TokenModel> RefreshToken(TokenModel tokenModel)
    {
        if (tokenModel is null)
        {
            //return badrequest
            return new TokenModel()
            {
                AccessToken = "Error",
                RefreshToken = "Invallid client request"
            };
        }

        string? accessToken = tokenModel.AccessToken;
        string? refreshToken = tokenModel.RefreshToken;

        var principal = GetPrincipalFromExpiredToken(accessToken);
        if (principal == null)
        {
            //return badrequest
            return new TokenModel()
            {
                AccessToken = "Error",
                RefreshToken = "Invallid access token or refresh token"
            };
        }

        string username = principal.Identity.Name;

        var user = await _userManager.FindByNameAsync(username);

        if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
        {
            //return badrequest
            return new TokenModel()
            {
                AccessToken = "Error",
                RefreshToken = "Invallid access token or refresh token"
            };
        }

        var newAccessToken = CreateToken(principal.Claims.ToList());
        var newRefreshToken = GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        await _userManager.UpdateAsync(user);

        return new TokenModel
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
            RefreshToken = newRefreshToken
        };
    }

    public async Task<Response> Revoke(string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null)
        {
            //return badrequest
            return new Response()
            {
                Status = "Error",
                Message = "Invalid user name"
            };
        }

        user.RefreshToken = null;
        await _userManager.UpdateAsync(user);
        //return 
        return new Response()
        {
            Status = "Success"
        };
    }

    public async Task RevokeAll()
    {
        var users = _userManager.Users.ToList();
        foreach (var user in users)
        {
            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
        }
    }

    private JwtSecurityToken CreateToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
        return token;
    }

    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return principal;

    }
}