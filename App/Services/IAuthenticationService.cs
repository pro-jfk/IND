using App.Auth;

namespace App.Services;

public interface IAuthenticationService
{
    Task<Response> Revoke(string username);
    Task RevokeAll();
    Task<TokenModel> RefreshToken(TokenModel tokenModel);
    Task<Response> RegisterAdmin(RegisterModel model);
    Task<Response> Register(RegisterModel model);
    Task<LoginResponse> Login(LoginModel model);
}