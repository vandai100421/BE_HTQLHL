//using BTLQuanLy.Data;
//using BTLQuanLy.Models;
using BTLQuanLy.Data;
using BTLQuanLy.Models;
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
    public class HocVienController : ControllerBase
    {
        private MyDbContext _context;
        public HocVienController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //[Authorize]
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
        //[Authorize]
        public IActionResult Create(HocVienRequest request)
        {
            try
            {
                var result = _context.Database.ExecuteSqlRaw($"createHocVien N'{request.TenHocVien}', '{request.NgaySinh}', {request.CapBacId}, {request.ChucVuId}, {request.GioiTinh}, N'{request.QueQuan}', '{request.SoDienThoai}', '{DateTime.Now}', 0, {request.DonViId}, {request.KhoaHoc}, {request.ThoiGianBatDau}, {request.ThoiGianKetThuc}, {request.LoaiHocVien}");
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
        //[Authorize]
        public IActionResult Update(int id, HocVienRequest request)
        {
            try
            {
                var hocVien = _context.HocViens.SingleOrDefault(x => x.Id == id);
                if (hocVien != null)
                {
                    var result = _context.Database.ExecuteSqlRaw($"updateHocVienById {id}, N'{request.TenHocVien}', '{request.NgaySinh}', {request.CapBacId}, {request.ChucVuId}, {request.GioiTinh}, N'{request.QueQuan}', '{request.SoDienThoai}', '{DateTime.Now}', 0, {request.DonViId}, {request.KhoaHoc}, {request.ThoiGianBatDau}, {request.ThoiGianKetThuc}, {request.LoaiHocVien}");
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
        //[Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                var hocVien = _context.HocViens.SingleOrDefault(x => x.Id == id);
                if (hocVien != null)
                {
                    var result = _context.Database.ExecuteSqlRaw($"deleteHocVien {id}");
                    if (result == 1)
                    {
                        return Ok(new
                        {
                            status = "success",
                            message = "Xóa học viên thành công"
                        });
                    }
                    else
                    {
                        return BadRequest();
                    }
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
        //[Authorize]
        public IActionResult Search([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page)
        {
            try
            {
                var list = _context.HocVienResponses.FromSqlRaw($"searchHocVien N'{q ?? ""}', {limit}, {page}").ToList();
                var total = _context.HocViens.Where(x => EF.Functions.Like(x.TenHocVien, $"%{q ?? ""}%")).Count();
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
    }
}
