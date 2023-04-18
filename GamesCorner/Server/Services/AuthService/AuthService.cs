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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super cool key"))
        };
    }
}