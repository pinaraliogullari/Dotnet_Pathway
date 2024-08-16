using BookStoreWebApi.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BookStoreWebApi.TokenOperations.Models
{
    public class TokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(User user)
        {
            Token tokenModel = new();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            tokenModel.Expiration = DateTime.Now.AddMinutes(15);
            JwtSecurityToken securityToken = new(

                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                notBefore: DateTime.UtcNow,
                expires: tokenModel.Expiration,
                signingCredentials: credentials
                );
            JwtSecurityTokenHandler tokenHandler = new();
            tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
            tokenModel.RefreshToken = CreateRefreshToken();

            return tokenModel;

        }

        private string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
