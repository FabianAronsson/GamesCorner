using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace GamesCorner.Client.Services.AuthService;

public class AuthService : IAuthService
{
    public string GenerateToken(AuthenticationState state)
    {
        var claims2 = state.User.Identities.FirstOrDefault().Claims.Where(c => c.Value.Equals("Administrator") || c.Value.Equals("admin@admin.com")) ;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super cool key"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var secToken = new JwtSecurityToken(
            signingCredentials: credentials,
            issuer: "GamesCorner",
            audience: "GamesCorner",
            claims: claims2,
            expires: DateTime.UtcNow.AddMinutes(5));

        var handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(secToken);
    }
}
