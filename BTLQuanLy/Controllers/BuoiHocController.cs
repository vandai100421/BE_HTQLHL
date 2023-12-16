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
    public class BuoiHocController : ControllerBase
    {
        private MyDbContext _context;
        public BuoiHocController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, BuoiHocRequest request)
        {
            try
            {
                var buoiHoc = _context.BuoiHocs.SingleOrDefault(x => x.Id == id);
                if (buoiHoc != null)
                {
                    System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                    var keHoach = _context.KHHuanLuyens.SingleOrDefault(x => x.Id == request.KeHoachId);
                    if (Int32.Parse(currentUser.FindFirst("role_").Value) == 2)
                    {
                        var isRole = _context.CheckRoleResponses.FromSqlRaw($"checkRole {Int32.Parse(currentUser.FindFirst("donViId").Value)}, {keHoach.DonViId}").ToList()[0].IsRole;
                        if (isRole == 0)
                        {
                            return Unauthorized();
                        }
                    }
                    var result = _context.Database.ExecuteSqlRaw($"updateBuoiHoc {id}, {request.KeHoachId}, '{request.ThoiGian}', {request.ThuTu}, '{DateTime.Now}', {Int32.Parse(currentUser.FindFirst("userId").Value)}");
                    return Ok(new
                    {
                        status = "success",
                        message = "Cập nhật buổi học thành công",
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

        [HttpGet("CreateByKHId/{id}")]
        [Authorize]
        public IActionResult CreateByKHId(int id)
        {
            try
            {
                var keHoach = _context.KHHuanLuyens.SingleOrDefault(x => x.Id == id);
                if (keHoach != null)
                {
                    if (keHoach.DaTaoBH == 1)
                    {
                        return BadRequest();
                    }
                    System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                    if (Int32.Parse(currentUser.FindFirst("role_").Value) == 2)
                    {
                        var isRole = _context.CheckRoleResponses.FromSqlRaw($"checkRole {Int32.Parse(currentUser.FindFirst("donViId").Value)}, {keHoach.DonViId}").ToList()[0].IsRole;
                        if (isRole == 0)
                        {
                            return Unauthorized();
                        }
                    }
                    var result = _context.Database.ExecuteSqlRaw($"createBuoiHoc {id}, '{DateTime.Now}', {Int32.Parse(currentUser.FindFirst("userId").Value)}");
                    return Ok(new
                    {
                        status = "success",
                        message = "Tạo buổi học thành công",
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

        [HttpGet("GetAllByKHId/{id}")]
        [Authorize]
        public IActionResult GetAllByKHId(int id)
        {
            try
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                var keHoach = _context.KHHuanLuyens.SingleOrDefault(x => x.Id == id);
                if (Int32.Parse(currentUser.FindFirst("role_").Value) == 2)
                {
                    var isRole = _context.CheckRoleResponses.FromSqlRaw($"checkRole {Int32.Parse(currentUser.FindFirst("donViId").Value)}, {keHoach.DonViId}").ToList()[0].IsRole;
                    if (isRole == 0)
                    {
                        return Unauthorized();
                    }
                }
                var list = _context.BuoiHocs.FromSqlRaw($"getAllBuoiHoc {id}").ToList();
                return Ok(new
                {
                    status = "success",
                    data = list,
                });
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
                var buoiHoc = _context.BuoiHocs.SingleOrDefault(x => x.Id == id);
                if (buoiHoc != null)
                {
                    System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                    var keHoach = _context.KHHuanLuyens.SingleOrDefault(x => x.Id == buoiHoc.KeHoachId);
                    if (Int32.Parse(currentUser.FindFirst("role_").Value) == 2)
                    {
                        var isRole = _context.CheckRoleResponses.FromSqlRaw($"checkRole {Int32.Parse(currentUser.FindFirst("donViId").Value)}, {keHoach.DonViId}").ToList()[0].IsRole;
                        if (isRole == 0)
                        {
                            return Unauthorized();
                        }
                    }
                    var result = _context.Database.ExecuteSqlRaw($"deleteBuoiHoc {id}");
                    return Ok(new
                    {
                        status = "success",
                        message = "Xóa buổi học thành công",
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
