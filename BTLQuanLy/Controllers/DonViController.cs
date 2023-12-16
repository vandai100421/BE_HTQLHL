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
    public class DonViController : ControllerBase
    {
        private MyDbContext _context;
        public DonViController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        [Authorize]
        public IActionResult GetAll()
        {
            try
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                var donViId = Int32.Parse(currentUser.FindFirst("role_").Value) == 1 ? 0 : Int32.Parse(currentUser.FindFirst("donViId").Value);
                var list = _context.DonVis.FromSqlRaw($"getAllDonViById 0").ToList();
                return Ok(new
                {
                    status = "success",
                    data = list.Count>0? list[0]:null,
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(DonViRequest request)
        {
            try
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                if (Int32.Parse(currentUser.FindFirst("role_").Value) == 2)
                {
                    var isRole = _context.CheckRoleResponses.FromSqlRaw($"checkRole {Int32.Parse(currentUser.FindFirst("donViId").Value)}, {request.DonViId}").ToList()[0].IsRole;
                    if (isRole == 0)
                    {
                        return Unauthorized();
                    }
                }
                var result = _context.Database.ExecuteSqlRaw($"createDonVi N'{request.TenDonVi}', '{request.NgayThanhLap}', {request.DonViId}, {request.LoaiDonViId}, {request.CapDonViId}, {request.TrangThai}, {Int32.Parse(currentUser.FindFirst("userId").Value)}, '{DateTime.Now}'");
                if (result == 1)
                {
                    return Ok(new
                    {
                        status = "success",
                        message = "Thêm đơn vị thành công"
                    });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, DonViRequest request)
        {
            try
            {
                var donVi = _context.DonVis.SingleOrDefault(x => x.Id == id);
                if (donVi != null)
                {
                    System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                    if (Int32.Parse(currentUser.FindFirst("role_").Value) == 2)
                    {
                        var isRole = _context.CheckRoleResponses.FromSqlRaw($"checkRole {Int32.Parse(currentUser.FindFirst("donViId").Value)}, {request.DonViId}").ToList()[0].IsRole;
                        if (isRole == 0)
                        {
                            return Unauthorized();
                        }
                    }
                    var result = _context.Database.ExecuteSqlRaw($"updateDonViById {id}, N'{request.TenDonVi}', '{request.NgayThanhLap}', '{request.NgayGiaiTan}', {request.DonViId}, {request.LoaiDonViId}, {request.CapDonViId}, {request.TrangThai},{Int32.Parse(currentUser.FindFirst("userId").Value)}, '{DateTime.Now}'");
                    if (result == 1)
                    {
                        return Ok(new
                        {
                            status = "success",
                            message = "Cập nhật đơn vị thành công"
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

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                var donVi = _context.DonVis.SingleOrDefault(x => x.Id == id);
                if (donVi != null)
                {
                    System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                    if (Int32.Parse(currentUser.FindFirst("role_").Value) == 2)
                    {
                        var isRole = _context.CheckRoleResponses.FromSqlRaw($"checkRole {Int32.Parse(currentUser.FindFirst("donViId").Value)}, {id}").ToList()[0].IsRole;
                        if (isRole == 0)
                        {
                            return Unauthorized();
                        }
                    }
                    var result = _context.Database.ExecuteSqlRaw($"deleteDonVi {id}");
                    if (result == 1)
                    {
                        return Ok(new
                        {
                            status = "success",
                            message = "Xóa đơn vị thành công"
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
        [Authorize]
        public IActionResult Search([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page)
        {
            try
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                var donViId = Int32.Parse(currentUser.FindFirst("role_").Value) == 1 ? 0 : Int32.Parse(currentUser.FindFirst("donViId").Value);
                var list = _context.DonViResponses.FromSqlRaw($"searchDonVi N'{q ?? ""}', {limit}, {page}, {donViId}").ToList();
                var total = _context.TotalResponses.FromSqlRaw($"getToTalDonVi N'{q ?? ""}', {limit}, {page}, {donViId}").ToList()[0].Total;
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
