using BTLQuanLy.Data;
using BTLQuanLy.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Controllers
{
    public class KetQuaHLController : Controller
    {
        private MyDbContext _context;
        public KetQuaHLController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        [Authorize]
        public IActionResult Search([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page, [FromQuery(Name = "keHoachId")] int keHoachId)
        {
            try
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                var keHoach = _context.KHHuanLuyens.SingleOrDefault(x => x.Id == keHoachId);
                if (Int32.Parse(currentUser.FindFirst("role_").Value) == 2)
                {
                    var isRole = _context.CheckRoleResponses.FromSqlRaw($"checkRole {Int32.Parse(currentUser.FindFirst("donViId").Value)}, {keHoach.DonViId}").ToList()[0].IsRole;
                    if (isRole == 0)
                    {
                        return Unauthorized();
                    }
                }
                var list = _context.KetQuaHLResponses.FromSqlRaw($"searchKetQua N'{q ?? ""}', {limit}, {page}, {keHoachId}").ToList();
                var total = _context.TotalResponses.FromSqlRaw($"getTotalKetQua N'{q ?? ""}', {limit}, {page}, {keHoachId}").ToList()[0].Total;
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

        [HttpGet("CreateByKHId/{id}")]
        [Authorize]
        public IActionResult CreateByKHId(int id)
        {
            try
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                var keHoach = _context.KHHuanLuyens.SingleOrDefault(x => x.Id == id);
                if (keHoach != null)
                {
                    if (Int32.Parse(currentUser.FindFirst("role_").Value) == 2)
                    {
                        var isRole = Int32.Parse(currentUser.FindFirst("donViId").Value) == keHoach.DonViId ? 1 : 0;
                        if (isRole == 0)
                        {
                            return Unauthorized();
                        }
                    }
                    var result = _context.Database.ExecuteSqlRaw($"createKetQua {id}, '{DateTime.Now}', {Int32.Parse(currentUser.FindFirst("userId").Value)}, {keHoach.DonViId}");
                    return Ok(new
                    {
                        status = "success",
                        message = "Thêm kết quả thành công"
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

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, KetQuaHLRequest request)
        {
            try
            {
                var ketQua = _context.KetQuaHLs.SingleOrDefault(x => x.Id == id);
                if (ketQua != null)
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
                    var result = _context.Database.ExecuteSqlRaw($"updateKetQua {id}, {request.KeHoachID}, {request.HocVienId}, {request.DonViId}, {request.KetQua}, {Int32.Parse(currentUser.FindFirst("userId").Value)}, '{DateTime.Now}'");
                    return Ok(new
                    {
                        status = "success",
                        message = "Cập nhật kết quả thành công"
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
                var ketQua = _context.KetQuaHLs.SingleOrDefault(x => x.Id == id);
                if (ketQua != null)
                {
                    System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                    if (Int32.Parse(currentUser.FindFirst("role_").Value) == 2)
                    {
                        var isRole = Int32.Parse(currentUser.FindFirst("donViId").Value) == ketQua.DonViId ? 1 : 0;
                        if (isRole == 0)
                        {
                            return Unauthorized();
                        }
                    }
                    var result = _context.Database.ExecuteSqlRaw($"deleteKetQua {id}");
                    return Ok(new
                    {
                        status = "success",
                        message = "Xóa kết quả thành công"
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
