using Microsoft.IdentityModel.Tokens;

namespace GamesCorner.Server.Services.AuthService;

public interface IAuthService
{
    public bool ValidateToken(string authToken);
    public TokenValidationParameters GetValidationParameters();
}