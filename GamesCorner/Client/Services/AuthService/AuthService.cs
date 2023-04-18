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
        var claims2 = state.User.Identities.FirstOrDefault().Claims.Where(c => c.Value.Equals("Administrator") || c.Value.Equals("admin@admin.com"));
        if (claims2 == null) 
        {
            claims2 = new List<Claim>();
        }
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1"));
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
