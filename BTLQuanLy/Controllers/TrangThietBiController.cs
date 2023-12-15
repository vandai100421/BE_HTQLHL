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
    public class TrangThietBiController : ControllerBase
    {
        private MyDbContext _context;
        public TrangThietBiController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page)
        {
            try
            {
                var list = _context.TrangThietBiResponses.FromSqlRaw($"searchTrangThietBi N'{q ?? ""}', {limit}, {page}").ToList();
                var total = _context.TotalTTBResponses.FromSqlRaw($"getTotalTrangThietBi N'{q ?? ""}', {limit}, {page}").ToList()[0].Total;
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
        public IActionResult Create(TrangThietBiRequest request)
        {
            try
            {
                var result = _context.Database.ExecuteSqlRaw($"createTrangThietBi N'{request.TenTTB}', {request.CapDo}, {request.TinhTrang}, N'{request.MoTa}', N'{request.DiaDiem}', {request.DonViId}, 0, '{DateTime.Now}'");
                return Ok(new
                {
                    status = "success",
                    message = "Thêm trang thiết bị thành công",
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TrangThietBiRequest request)
        {
            try
            {
                var result = _context.Database.ExecuteSqlRaw($"updateTrangThietBi {id}, N'{request.TenTTB}', {request.CapDo}, {request.TinhTrang}, N'{request.MoTa}', N'{request.DiaDiem}', {request.DonViId}, 0, '{DateTime.Now}'");
                return Ok(new
                {
                    status = "success",
                    message = "Cập nhật trang thiết bị thành công",
                });
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
                var trangThietBi = _context.TrangThietBis.SingleOrDefault(x => x.Id == id);
                if (trangThietBi != null)
                {
                    var result = _context.Database.ExecuteSqlRaw($"deleteTTB {id}");
                    return Ok(new
                    {
                        status = "success",
                        message = "Xóa trang thiết bị thành công"
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
