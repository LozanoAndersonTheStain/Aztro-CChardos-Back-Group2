using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace aztro_cchardos_back_group2.Application.Services
{
    public class TokenService(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;

        public string GenerateToken(string username, string role)
        {
            var jwtKey = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                Console.WriteLine("JWT Key is null or empty");
                throw new InvalidOperationException("JWT Key is not configured");
            }

            Console.WriteLine($"JWT Key length: {jwtKey.Length}");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            if (securityKey.KeySize < 128)
            {
                throw new InvalidOperationException($"JWT Key size is too small. Current size: {securityKey.KeySize} bits");
            }

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}