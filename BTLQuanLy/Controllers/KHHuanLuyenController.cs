using BTLQuanLy.Data;
using BTLQuanLy.Models;
using BTLQuanLy.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KHHuanLuyenController : ControllerBase
    {
        private MyDbContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        public KHHuanLuyenController(MyDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("searchLevelUpper")]
        [Authorize]
        public IActionResult SearchLevelUpper([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page, [FromQuery(Name = "startDay")] string startDay, [FromQuery(Name = "endDay")] string endDay)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var user = _context.NguoiDungs.SingleOrDefault(x => x.Id == Int32.Parse(currentUser.FindFirst("userId").Value));
            var list = _context.KHHuanLuyenResponses.FromSqlRaw($"searchKeHoachCapTren {user.DonViId}, N'{q ?? ""}', {limit}, {page}, '{startDay??"0"}', '{endDay??"0"}'").ToList();
            var total = _context.TotalKHResponses.FromSqlRaw($"getTotalKHCapTren {user.DonViId}, N'{q ?? ""}', {limit}, {page}, '{startDay ?? "0"}', '{endDay ?? "0"}'").ToList()[0].Total;
            return Ok(new
            {
                status = "success",
                data = list,
                page,
                limit,
                total
            });
        }

        [HttpGet("searchLevelYourself")]
        [Authorize]
        public IActionResult SearchLevelYourself([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page, [FromQuery(Name = "startDay")] string startDay, [FromQuery(Name = "endDay")] string endDay)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var user = _context.NguoiDungs.SingleOrDefault(x => x.Id == Int32.Parse(currentUser.FindFirst("userId").Value));
            var list = _context.KHHuanLuyenResponses.FromSqlRaw($"searchKeHoachCapMinh {user.DonViId}, N'{q ?? ""}', {limit}, {page}, '{startDay ?? "0"}', '{endDay ?? "0"}'").ToList();
            var total = _context.TotalKHResponses.FromSqlRaw($"getTotalKHCapMinh {user.DonViId}, N'{q ?? ""}', {limit}, {page}, '{startDay ?? "0"}', '{endDay ?? "0"}'").ToList()[0].Total;
            return Ok(new
            {
                status = "success",
                data = list,
                page,
                limit,
                total
            });
        }

        [HttpGet("searchLevelLower")]
        [Authorize]
        public IActionResult SearchLevelLower([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page, [FromQuery(Name = "startDay")] string startDay, [FromQuery(Name = "endDay")] string endDay)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var user = _context.NguoiDungs.SingleOrDefault(x => x.Id == Int32.Parse(currentUser.FindFirst("userId").Value));
            var list = _context.KHHuanLuyenResponses.FromSqlRaw($"searchKeHoachCapDuoi {user.DonViId}, N'{q ?? ""}', {limit}, {page}, '{startDay ?? "0"}', '{endDay ?? "0"}'").ToList();
            var total = _context.TotalKHResponses.FromSqlRaw($"getTotalKHCapDuoi {user.DonViId}, N'{q ?? ""}', {limit}, {page}, '{startDay ?? "0"}', '{endDay ?? "0"}'").ToList()[0].Total;
            return Ok(new
            {
                status = "success",
                data = list,
                page,
                limit,
                total
            });
        }

        [HttpPost]
        public IActionResult Create([FromForm]KHHuanLuyenRequest request)
        {
            try
            {
                if (request.Link.Length > 0)
                {
                    using(FileStream filestream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\public\\" + request.Link.FileName))
                    {
                        request.Link.CopyTo(filestream);

                    }
                }
                var result = _context.Database.ExecuteSqlRaw($"createKeHoach N'{request.TenKeHoach}', N'{request.NoiDung}', '{request.ThoiGianBatDau}', '{request.ThoiGianKetThuc}',  0, '{DateTime.Now}', '{"/public/" + request.Link.FileName}', {request.SoBuoiHoc}, {request.SoGio}, {request.DonViId}");
                _context.Database.ExecuteSqlRaw($"createBuoiHoc '{DateTime.Now}', 0");
                return Ok(new
                {
                    status = "success",
                    message = "Thêm kế hoạch thành công",
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm]KHHuanLuyenRequest request)
        {
            try
            {
                var keHoach = _context.KHHuanLuyens.SingleOrDefault(x => x.Id == id);
                if (keHoach != null)
                {
                    if (request.Link.Length > 0)
                    {
                        using (FileStream filestream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\public\\" + request.Link.FileName))
                        {
                            request.Link.CopyTo(filestream);

                        }
                    }
                    var result = _context.Database.ExecuteSqlRaw($"updateKeHoach {id}, N'{request.TenKeHoach}', N'{request.NoiDung}', '{request.ThoiGianBatDau}', '{request.ThoiGianKetThuc}',  0, '{DateTime.Now}', '{"/public/" + request.Link.FileName}'");
                    return Ok(new
                    {
                        status = "success",
                        message = "Cập nhật kế hoạch thành công",
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
                var keHoach = _context.KHHuanLuyens.SingleOrDefault(x => x.Id == id);
                if (keHoach != null)
                {
                    var result = _context.Database.ExecuteSqlRaw($"deleteKeHoach {id}");
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
    }
}
