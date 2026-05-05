using FastPartsApi.Data;
using FastPartsApi.DTO;
using FastPartsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FastPartsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;

        public AuthController(IConfiguration config, AppDbContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            if (_context.Users.Any(u => u.Login == dto.Login))
            {
                return BadRequest(new { message = "Логин уже существует" });
            }

            var newUser = new User
            {
                Login = dto.Login,
                Password = dto.Password,
                FullName = dto.FullName,
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return Ok(new { message = "Пользователь успешно зарегистрирован" });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == dto.Login);

            if (user == null || dto.Password != user.Password)
                return Unauthorized(new { message = "Неверный логин или пароль" });

            string token = GenerateJwtToken(user);

            return Ok(new AuthResponse
            {
                Token = token,
                Login = user.Login,
                IdUser = user.IdUser
            });
        }

        private string GenerateJwtToken(User user)
        {
            var jwt = _config.GetSection("Jwt");

            var claims = new[]
            {
            new Claim("IdUser", user.IdUser.ToString()),
            new Claim("Login", user.Login)
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

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private static bool VerifyPassword(string password, string hashedPassword)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var computedHash = Convert.ToBase64String(hashedBytes);
                return computedHash == hashedPassword;
            }
        }
    }
}
