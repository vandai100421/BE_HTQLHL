using BTLQuanLy.Common;
using BTLQuanLy.Data;
using BTLQuanLy.Models;
using BTLQuanLy.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BTLQuanLy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private MyDbContext _context;
        private AppSettings _appSettings;
        public AuthController(MyDbContext context, IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _context = context;
            _appSettings = optionsMonitor.CurrentValue;
        }

        private string GenerateToken(NguoiDung nguoiDung)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("userId", nguoiDung.Id.ToString()),
                    new Claim("userName", nguoiDung.TenNguoiDung),
                    new Claim(ClaimTypes.Role, nguoiDung.NhomNDId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var nguoiDung = _context.NguoiDungs.SingleOrDefault(x => x.TenNguoiDung == request.TenNguoiDung && x.MatKhau == Encryptor.MD5Hash(request.MatKhau));
            if (nguoiDung != null)
            {
                return Ok(new
                {
                    status = "success",
                    data = GenerateToken(nguoiDung),
                    message = "Đăng nhập thành công"
                });
            }
            else
            {
                return Ok(new
                {
                    status = "error",
                    message = "Tên người dùng hoặc mật khẩu không đúng"
                });
            }
        }
    }
}
