using FastPartsApi.Data;
using FastPartsApi.DTO;
using FastPartsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FastPartsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;

        public AdminAuthController(IConfiguration config, AppDbContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login(AdminLoginDto dto)
        {
            var admin = _context.Admins
                .FirstOrDefault(a => a.Login == dto.Login && a.Password == dto.Password);

            if (admin == null)
                return Unauthorized(new { message = "Неверный логин или пароль администратора" });

            string token = GenerateJwtToken(admin);

            return Ok(new
            {
                Token = token,
                Login = admin.Login,
                IdAdmin = admin.IdAdmin
            });
        }


        private string GenerateJwtToken(Admin admin)
        {
            var jwt = _config.GetSection("Jwt");

            var claims = new[]
            {
            new Claim("AdminId", admin.IdAdmin.ToString()),
            new Claim("Username", admin.Login),
            // ВАЖНО: добавляем claim роли
            new Claim(ClaimTypes.Role, "Администратор")
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(jwt["ExpiresMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
