using Microsoft.AspNetCore.Components.Authorization;

namespace GamesCorner.Client.Services.AuthService;

public interface IAuthService
{
    public string GenerateToken(AuthenticationState state);
}