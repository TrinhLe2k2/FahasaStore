using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FahasaStoreApp.Services
{
    public interface IJwtTokenDecoder
    {
        ClaimsPrincipal DecodeToken(string token);
    }

    public class JwtTokenDecoder : IJwtTokenDecoder
    {
        private readonly string _key;

        public JwtTokenDecoder()
        {
            _key = "ThisIsTheSecureKey1234567890ThisIsTheSecureKey12345678901234567890";
        }

        public ClaimsPrincipal DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_key);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            return principal;
        }
    }
}
