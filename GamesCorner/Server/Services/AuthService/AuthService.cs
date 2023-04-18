using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text;

namespace GamesCorner.Server.Services.AuthService;

public class AuthService : IAuthService
{
    public bool ValidateToken(string authToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = GetValidationParameters();

        SecurityToken validatedToken;
        try
        {
            IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
        }
        catch (Exception e)
        {
            return false;
        }
       

        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(authToken);
        if (!jwt.Claims.Any(c => c.Value.Equals("Administrator") || c.Value.Equals("admin@admin.com")))
        {
            return false;
        }

        return true;
    }

    public TokenValidationParameters GetValidationParameters()
    {
        return new TokenValidationParameters()
        {
            ValidateLifetime = false,
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidIssuer = "GamesCorner",
            ValidAudience = "GamesCorner",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1"))
        };
    }
}