using LoginApi.Models.Response;
using LoginApi.Services.Interfaces;
using LoginApi.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginApi.Services.Implementations
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public String GenerateToken(User user)
        {
            var expireConfig = Convert.ToDouble(_configuration["Jwt:ExpireMinute"]!.ToString());
            //var expire = DateTime.UtcNow.AddHours(expireConfig);

             var expire = DateTime.UtcNow.AddMinutes(expireConfig);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expire,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

          
        }
    }
}