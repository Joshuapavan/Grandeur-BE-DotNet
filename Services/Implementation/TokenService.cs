using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Grandeur_BE_DotNet.Models.Entitiles;
using Microsoft.IdentityModel.Tokens;

namespace Grandeur_BE_DotNet.Services.Implementation;

public class TokenService(IConfiguration config) : ITokenService
{
    public String CreateToken(User user)
    {
        var tokenKey = config["TokenKey"] ?? throw new Exception("Token key not found");
        if (tokenKey.Length < 64) throw new Exception("Token Key length is lesser than 64 characters");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var claims = new List<Claim>
        {
            new (ClaimTypes.Name, user.Email),
            new (ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
