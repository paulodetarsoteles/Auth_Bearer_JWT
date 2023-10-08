using Auth_Bearer_JWT.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth_Bearer_JWT.Service
{
    public static class TokenService
    {
        public static string GenerateToken(User user)
        {
            JwtSecurityTokenHandler handler = new();

            byte[]? key = Encoding.ASCII.GetBytes(Settings.Secret);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Role)
                })
            };

            SecurityToken token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }
}
