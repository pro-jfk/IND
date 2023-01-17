// using Microsoft.AspNetCore.Identity;
// using Microsoft.Extensions.Configuration;
// using Microsoft.IdentityModel.Tokens;
// using System;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using Xunit;
//
// namespace UnitTests.Services;
//
//     public class JwtServiceTest
//     {
//         private readonly IConfiguration _configuration;
//         private readonly IdentityUser _user;
//
//         public JwtServiceTest()
//         {
//             // Set up the configuration with values needed for testing
//             _configuration = new ConfigurationBuilder()
//                 .AddInMemoryCollection(new[]
//                 {
//                     new KeyValuePair<string, string>("Jwt:Key", "test_key"),
//                     new KeyValuePair<string, string>("Jwt:Subject", "test_subject"),
//                     new KeyValuePair<string, string>("Jwt:Issuer", "test_issuer"),
//                     new KeyValuePair<string, string>("Jwt:Audience", "test_audience")
//                 })
//                 .Build();
//
//             // Set up an IdentityUser for testing
//             _user = new IdentityUser
//             {
//                 Id = "test_id",
//                 UserName = "test_username",
//                 Email = "test_email@example.com"
//             };
//         }
//
//         [Fact]
//         public void CreateToken_ReturnsTokenAndExpiration()
//         {
//             // Arrange
//             var jwtService = new JwtService(_configuration);
//
//             // Act
//             var result = jwtService.CreateToken(_user);
//
//             // Assert
//             Assert.NotNull(result.Token);
//             Assert.True(result.Expiration > DateTime.UtcNow);
//         }
//
//         [Fact]
//         public void CreateToken_TokenIsValidJwt()
//         {
//             // Arrange
//             var jwtService = new JwtService(_configuration);
//
//             // Act
//             var result = jwtService.CreateToken(_user);
//
//             // Assert
//             var tokenHandler = new JwtSecurityTokenHandler();
//             tokenHandler.ValidateToken(result.Token, new TokenValidationParameters(), out SecurityToken securityToken);
//             Assert.IsType<JwtSecurityToken>(securityToken);
//         }
//
//         [Fact]
//         public void CreateToken_TokenContainsExpectedClaims()
//         {
//             // Arrange
//             var jwtService = new JwtService(_configuration);
//
//             // Act
//             var result = jwtService.CreateToken(_user);
//
//             // Assert
//             var tokenHandler = new JwtSecurityTokenHandler();
//             var claimsPrincipal = tokenHandler.ValidateToken(result.Token, new TokenValidationParameters(),
//                 out SecurityToken securityToken);
//             Assert.Equal(_configuration["Jwt:Subject"], claimsPrincipal.FindFirst(JwtRegisteredClaimNames.Sub).Value);
//             Assert.Equal(_user.Id, claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
//             Assert.Equal(_user.UserName, claimsPrincipal.FindFirst(ClaimTypes.Name).Value);
//             Assert.Equal(_user.Email, claimsPrincipal.FindFirst(ClaimTypes.Email).Value);
//         }
//
//         [Fact]
//         public void CreateToken_TokenExpiresAfterExpectedDuration()
//         {
//             // Arrange
//             var jwtService = new JwtService(_configuration);
//             var expectedExpiration = DateTime.UtcNow.AddMinutes(JwtService.EXPIRATION_MINUTES);
//
//             // Act
//             var result = jwtService.CreateToken(_user);
//
//             // Assert
//             Assert.True(result.Expiration - expectedExpiration < TimeSpan.FromSeconds(1));
//         }
//
//         [Fact]
//         public void CreateToken_TokenHasExpectedIssuerAndAudience()
//         {
//             // Arrange
//             var jwtService = new JwtService(_configuration);
//
//             // Act
//             var result = jwtService.CreateToken(_user);
//
//             // Assert
//             var tokenHandler = new JwtSecurityTokenHandler();
//             var securityToken = tokenHandler.ReadToken(result.Token) as JwtSecurityToken;
//             Assert.Equal(_configuration["Jwt:Issuer"], securityToken.Issuer);
//             Assert.Equal(_configuration["Jwt:Audience"], securityToken.Audience);
//         }
//
//         [Fact]
//         public void CreateToken_TokenIsSignedWithExpectedKey()
//         {
//             // Arrange
//             var jwtService = new JwtService(_configuration);
//
//             // Act
//             var result = jwtService.CreateToken(_user);
//
//             // Assert
//             var tokenHandler = new JwtSecurityTokenHandler();
//             tokenHandler.ValidateToken(result.Token, new TokenValidationParameters
//             {
//                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
//             }, out SecurityToken securityToken);
//         }
//     }
//
//
