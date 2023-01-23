using System.IdentityModel.Tokens.Jwt;
using App.Auth;
using App.Services;
using Core.Entities.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuthenticateController : ApiController
{
    
    private readonly IConfiguration _configuration;

    public AuthenticateController(
        IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromServices] IAuthenticationService authenticationService,
        [FromBody] LoginModel model)
    {
        var result = authenticationService.Login(model);
        if (result.Result.RefreshToken == null)
        {
            return Unauthorized();
        }

        return Ok(result.Result);
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromServices] IAuthenticationService authenticationService,
        [FromBody] RegisterModel model)
    {
        var result = authenticationService.Register(model);
        if (result.Result.Status == "Error")
        {
            return StatusCode(StatusCodes.Status500InternalServerError, result.Result);
        }

        return Ok(result.Result);
    }

    [HttpPost]
    [Route("register-admin")]
    public async Task<IActionResult> RegisterAdmin([FromServices] IAuthenticationService authenticationService,
        [FromBody] RegisterModel model)
    {
        var result = authenticationService.RegisterAdmin(model);
        if (result.Result.Status == "Error")
        {
            return StatusCode(StatusCodes.Status500InternalServerError, result.Result);
        }

        return Ok(result.Result);
    }

    [HttpPost]
    [Route("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromServices] IAuthenticationService authenticationService,[FromBody] TokenModel tokenModel)
    {
        var result = authenticationService.RefreshToken(tokenModel);
        if (result.Result.AccessToken == "Error")
        {
            return BadRequest(result.Result.RefreshToken);
        }

        return new ObjectResult(new
        {
            accessToken = result.Result.AccessToken,
            refreshToken = result.Result.RefreshToken
        });
    }

    [Authorize(Roles = UserRoles.Admin)]
    [HttpPost]
    [Route("revoke/{username}")]
    public async Task<IActionResult> Revoke([FromServices] IAuthenticationService authenticationService,
        string username)
    {
        var result = authenticationService.Revoke(username);
        if (result.Result.Status == "Error")
        {
            return BadRequest(result.Result.Message);
        }

        return NoContent();
    }

    [Authorize]
    [HttpPost]
    [Route("revoke-all")]
    public async Task<IActionResult> RevokeAll([FromServices] IAuthenticationService authenticationService)
    {
        var result = authenticationService.RevokeAll();
        return NoContent();
    }
}