using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Utilities.Helpers;

public static class JWTHelper
{
    public static string CreateJWTToken(SymmetricSecurityKey key, int userId, string email)
    {
        List<Claim> claims = new() {
                        new Claim(ClaimTypes.NameIdentifier, userId.ToString(), ClaimValueTypes.Integer32),
                        new Claim(ClaimTypes.Email, email)
            };

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    public static string CreateJWTRefreshToken()
    {
        return TokenHelper.CreateRandomToken();
    }
}