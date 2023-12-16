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
        [Authorize(Roles = "2")]
        public IActionResult SearchLevelUpper([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page, [FromQuery(Name = "startDay")] string startDay, [FromQuery(Name = "endDay")] string endDay)
        {
            try
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                var donViId = Int32.Parse(currentUser.FindFirst("donViId").Value);
                var list = _context.KHHuanLuyenResponses.FromSqlRaw($"searchKeHoachCapTren {donViId}, N'{q ?? ""}', {limit}, {page}, '{startDay ?? "0"}', '{endDay ?? "0"}'").ToList();
                var total = _context.TotalResponses.FromSqlRaw($"getTotalKHCapTren {donViId}, N'{q ?? ""}', {limit}, {page}, '{startDay ?? "0"}', '{endDay ?? "0"}'").ToList()[0].Total;
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

        [HttpGet("searchLevelYourself")]
        [Authorize(Roles = "2")]
        public IActionResult SearchLevelYourself([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page, [FromQuery(Name = "startDay")] string startDay, [FromQuery(Name = "endDay")] string endDay)
        {
            try
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                var donViId = Int32.Parse(currentUser.FindFirst("donViId").Value);
                var list = _context.KHHuanLuyenResponses.FromSqlRaw($"searchKeHoachCapMinh {donViId}, N'{q ?? ""}', {limit}, {page}, '{startDay ?? "0"}', '{endDay ?? "0"}'").ToList();
                var total = _context.TotalResponses.FromSqlRaw($"getTotalKHCapMinh {donViId}, N'{q ?? ""}', {limit}, {page}, '{startDay ?? "0"}', '{endDay ?? "0"}'").ToList()[0].Total;
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
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                var donViId = Int32.Parse(currentUser.FindFirst("donViId").Value);
                var list = _context.KHHuanLuyenResponses.FromSqlRaw($"searchKeHoachCapMinh {donViId}, N'{q ?? ""}', {limit}, {page}, '{startDay ?? "0"}', '{endDay ?? "0"}'").ToList();
                var total = _context.TotalResponses.FromSqlRaw($"getTotalKHCapMinh {donViId}, N'{q ?? ""}', {limit}, {page}, '{startDay ?? "0"}', '{endDay ?? "0"}'").ToList()[0].Total;
                return Ok(new
                {
                    status = "success",
                    data = list,
                    page,
                    limit,
                    total
                });
            }
        }

        [HttpGet("searchLevelLower")]
        [Authorize(Roles = "2")]
        public IActionResult SearchLevelLower([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page, [FromQuery(Name = "startDay")] string startDay, [FromQuery(Name = "endDay")] string endDay)
        {
            try
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                var donViId = Int32.Parse(currentUser.FindFirst("donViId").Value);
                var list = _context.KHHuanLuyenResponses.FromSqlRaw($"searchKeHoachCapDuoi {donViId}, N'{q ?? ""}', {limit}, {page}, '{startDay ?? "0"}', '{endDay ?? "0"}'").ToList();
                var total = _context.TotalResponses.FromSqlRaw($"getTotalKHCapDuoi {donViId}, N'{q ?? ""}', {limit}, {page}, '{startDay ?? "0"}', '{endDay ?? "0"}'").ToList()[0].Total;
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

        [HttpGet("search")]
        [Authorize(Roles = "1")]
        public IActionResult Search([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page, [FromQuery(Name = "startDay")] string startDay= "1975-11-19 19:54:41.1751275", [FromQuery(Name = "endDay")] string endDay= "2100-11-19 19:54:41.1751275", [FromQuery(Name = "donViId")] int donViId=0)
        {
            try
            {
                var list = _context.KHHuanLuyenResponses.FromSqlRaw($"searchKeHoach {donViId}, N'{q ?? ""}', {limit}, {page}, '{startDay}', '{endDay}'").ToList();
                var total = _context.TotalResponses.FromSqlRaw($"getTotalKeHoach {donViId}, N'{q ?? ""}', {limit}, {page}, '{startDay}', '{endDay}'").ToList()[0].Total;
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
        public IActionResult Create([FromForm]KHHuanLuyenRequest request)
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
                var link = "0";
                if (request.Link !=null && request.Link.Length > 0)
                {
                    using(FileStream filestream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\public\\" + request.Link.FileName))
                    {
                        request.Link.CopyTo(filestream);
                        link = "/public/" + request.Link.FileName;
                    }
                }
                var result = _context.Database.ExecuteSqlRaw($"createKeHoach '{request.MaKeHoach}', N'{request.TenKeHoach}', N'{request.NoiDung}', '{request.ThoiGianBatDau}', '{request.ThoiGianKetThuc}',  {Int32.Parse(currentUser.FindFirst("userId").Value)}, '{DateTime.Now}', '{link}', {request.SoBuoiHoc}, {request.SoGio}, {request.DonViId}");
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
        [Authorize]
        public IActionResult Update(int id, [FromForm]KHHuanLuyenRequest request)
        {
            try
            {
                var keHoach = _context.KHHuanLuyens.SingleOrDefault(x => x.Id == id);
                if (keHoach != null)
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
                    var link = "0";
                    if (request.Link != null && request.Link.Length > 0)
                    {
                        using (FileStream filestream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\public\\" + request.Link.FileName))
                        {
                            request.Link.CopyTo(filestream);
                            link = "/public/" + request.Link.FileName;
                        }
                    }
                    var result = _context.Database.ExecuteSqlRaw($"updateKeHoach {id}, '{request.MaKeHoach}', N'{request.TenKeHoach}', N'{request.NoiDung}', '{request.ThoiGianBatDau}', '{request.ThoiGianKetThuc}',  {Int32.Parse(currentUser.FindFirst("userId").Value)}, '{DateTime.Now}', '{link}'");
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
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                var keHoach = _context.KHHuanLuyens.SingleOrDefault(x => x.Id == id);
                if (keHoach != null)
                {
                    System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                    if (Int32.Parse(currentUser.FindFirst("role_").Value) == 2)
                    {
                        var isRole = Int32.Parse(currentUser.FindFirst("donViId").Value) == keHoach.DonViId ? 1 : 0;
                        if (isRole == 0)
                        {
                            return Unauthorized();
                        }
                    }
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
