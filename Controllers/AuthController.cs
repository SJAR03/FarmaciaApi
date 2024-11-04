using FarmaciaApi.DTOs;
using FarmaciaApi.Models;
using FarmaciaApi.Models.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FarmaciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly FarmaciaDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(FarmaciaDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == loginDTO.Username);

            if (user == null || !VerifyPasswordHash(loginDTO.Password, user.Pwd, user.PasswordSalt))
            {
                return Unauthorized("Invalid credentials.");
            }

            var token = GenerateJwtToken(user);

            return Ok(new { token, id = user.IdUsuario });
        }

        private string GenerateJwtToken(Usuario user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.IdUsuario.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool VerifyPasswordHash(string password, string storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(Convert.FromBase64String(storedHash));
            }
        }
    }
}
