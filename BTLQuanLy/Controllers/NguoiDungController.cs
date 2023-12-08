using BTLQuanLy.Common;
using BTLQuanLy.Data;
using BTLQuanLy.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private MyDbContext _context;
        public NguoiDungController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        //[Authorize]
        public IActionResult Search([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page)
        {
            try
            {
                var list = _context.NguoiDungResponses.FromSqlRaw($"searchNguoiDung N'{q ?? ""}', {limit}, {page}").ToList();
                var total = _context.NguoiDungs.Count();
                return Ok(new
                {
                    status = "success",
                    data = list,
                    page,
                    limit,
                    total
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(NguoiDungRequest request)
        {
            try
            {
                var result = _context.Database.ExecuteSqlRaw($"createNguoiDung N'{request.TenNguoiDung}', N'{request.HoTen}', N'{request.Email}', {request.VaiTro}, N'{Encryptor.MD5Hash(request.MatKhau)}', {request.DonViId}, 0, '{DateTime.Now}'");
                return Ok(new
                {
                    status = "success",
                    message = "Thêm người dùng thành công",
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Update(int id, NguoiDungRequest request)
        {
            try
            {
                var result = _context.Database.ExecuteSqlRaw($"updateNguoiDungById {id}, N'{request.TenNguoiDung}', N'{request.HoTen}', N'{request.Email}', {request.VaiTro}, 0, '{DateTime.Now}'");
                return Ok(new
                {
                    status = "success",
                    message = "Cập nhật người dùng thành công",
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("changepass/{id}")]
        public IActionResult ChangePass(int id, NguoiDungRequest request)
        {
            try
            {
                var result = _context.Database.ExecuteSqlRaw($"changePass {id}, N'{Encryptor.MD5Hash(request.MatKhau)}', 0, '{DateTime.Now}'");
                return Ok(new
                {
                    status = "success",
                    message = "Cập nhật mật khẩu thành công",
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                var nguoiDung = _context.NguoiDungs.SingleOrDefault(x => x.Id == id);
                if (nguoiDung != null)
                {
                    _context.Remove(nguoiDung);
                    _context.SaveChanges();
                    return Ok(new
                    {
                        status = "success",
                        message = "Xóa người dùng thành công"
                    });
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
