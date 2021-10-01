using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthFx.AuthServer.Models;
using Microsoft.IdentityModel.Tokens;

namespace AuthFx.AuthServer
{
    public static class Utils
    {
        public static string GenerateToken(AppUser user, string securityKey, TimeSpan exp)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(securityKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "authfx",
                Issuer = "localhost",
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Name, user.DisplayName),
                        new Claim(ClaimTypes.NameIdentifier, user.UserName)
                    }),
                Expires = DateTime.UtcNow.Add(exp),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}