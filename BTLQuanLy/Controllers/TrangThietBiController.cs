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
        [Authorize]
        public IActionResult Search([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page)
        {
            try
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                var donViId = Int32.Parse(currentUser.FindFirst("role_").Value) == 1 ? 0 : Int32.Parse(currentUser.FindFirst("donViId").Value);
                var list = _context.TrangThietBiResponses.FromSqlRaw($"searchTrangThietBi N'{q ?? ""}', {limit}, {page}, {donViId}").ToList();
                var total = _context.TotalResponses.FromSqlRaw($"getTotalTrangThietBi N'{q ?? ""}', {limit}, {page}, {donViId}").ToList()[0].Total;
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
        [Authorize]
        public IActionResult Create(TrangThietBiRequest request)
        {
            try
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                if (Int32.Parse(currentUser.FindFirst("role_").Value) == 2)
                {
                    var isRole = Int32.Parse(currentUser.FindFirst("donViId").Value) == request.DonViId ? 1 : 0;
                    if (isRole == 0)
                    {
                        return Unauthorized();
                    }
                }
                var result = _context.Database.ExecuteSqlRaw($"createTrangThietBi N'{request.TenTTB}', {request.CapDo}, {request.TinhTrang}, N'{request.MoTa}', N'{request.DiaDiem}', {request.DonViId}, {Int32.Parse(currentUser.FindFirst("userId").Value)}, '{DateTime.Now}'");
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
                var trangThietBi = _context.TrangThietBis.SingleOrDefault(x => x.Id == id);
                if (trangThietBi != null)
                {
                    System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                    if (Int32.Parse(currentUser.FindFirst("role_").Value) == 2)
                    {
                        var isRole = Int32.Parse(currentUser.FindFirst("donViId").Value) == trangThietBi.DonViId ? 1 : 0;
                        if (isRole == 0)
                        {
                            return Unauthorized();
                        }
                    }
                    var result = _context.Database.ExecuteSqlRaw($"updateTrangThietBi {id}, N'{request.TenTTB}', {request.CapDo}, {request.TinhTrang}, N'{request.MoTa}', N'{request.DiaDiem}', {request.DonViId}, {Int32.Parse(currentUser.FindFirst("userId").Value)}, '{DateTime.Now}'");
                    return Ok(new
                    {
                        status = "success",
                        message = "Cập nhật trang thiết bị thành công",
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
                var trangThietBi = _context.TrangThietBis.SingleOrDefault(x => x.Id == id);
                if (trangThietBi != null)
                {
                    System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                    if (Int32.Parse(currentUser.FindFirst("role_").Value) == 2)
                    {
                        var isRole = Int32.Parse(currentUser.FindFirst("donViId").Value) == trangThietBi.DonViId ? 1 : 0;
                        if (isRole == 0)
                        {
                            return Unauthorized();
                        }
                    }
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
