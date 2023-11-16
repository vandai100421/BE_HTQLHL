//using BTLQuanLy.Data;
//using BTLQuanLy.Models;
using BTLQuanLy.Data;
using BTLQuanLy.Models;
using BTLQuanLy.Request;
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
    public class HocVienController : ControllerBase
    {
        private MyDbContext _context;
        public HocVienController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page)
        {
            try
            {
                var list = _context.HocVienResponses.FromSqlRaw($"getAllHocVien {limit}, {page}").ToList();
                return Ok(new
                {
                    status = "success",
                    data = list
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(HocVienRequest request)
        {
            try
            {
                var result = _context.Database.ExecuteSqlRaw($"createHocVien N'{request.TenHocVien}', '{request.NgaySinh}', {request.GioiTinh}, N'{request.QueQuan}', '{request.SoDienThoai}', '{DateTime.Now}', {request.DonViId}");
                return Ok(new
                {
                    status = "success",
                    data = request,
                    message = "Thêm học viên thành công"
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, HocVienRequest request)
        {
            try
            {
                var hocVien = _context.HocViens.SingleOrDefault(x => x.Id == id);
                if (hocVien != null)
                {
                    var result = _context.Database.ExecuteSqlRaw($"updateHocVienById {id}, N'{request.TenHocVien}', '{request.NgaySinh}', {request.GioiTinh}, N'{request.QueQuan}', '{request.SoDienThoai}', '{DateTime.Now}', {request.DonViId}");
                    return Ok(new
                    {
                        status = "success",
                        message = "Cập nhật học viên thành công"
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var hocVien = _context.HocViens.SingleOrDefault(x => x.Id == id);
                if (hocVien != null)
                {
                    _context.Remove(hocVien);
                    _context.SaveChanges();
                    return Ok(new
                    {
                        status = "success",
                        message = "Xóa học viên thành công"
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

        [HttpGet("search")]
        public IActionResult Search([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page)
        {
            try
            {
                var list = _context.HocVienResponses.FromSqlRaw($"searchHocVien {q}, {limit}, {page}").ToList();
                return Ok(new
                {
                    status = "success",
                    data = list
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
