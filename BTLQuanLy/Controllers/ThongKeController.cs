using BTLQuanLy.Data;
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
    public class ThongKeController : ControllerBase
    {
        private MyDbContext _context;
        public ThongKeController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetKTLevelYourself/{id}")]
        [Authorize]
        public IActionResult GetByDonViLevelYourself([FromQuery(Name = "keHoachId")] string keHoachId)
        {
            try
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                var list = _context.TKKetQuaResponses.FromSqlRaw($"getTKKetQua {Int32.Parse(currentUser.FindFirst("donViId").Value)}, {keHoachId}");
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

        [HttpGet("GetKTLevelLower/{id}")]
        [Authorize]
        public IActionResult GetKTLevelLower(int id, [FromQuery(Name = "keHoachId")] string keHoachId)
        {
            try
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
                var list = _context.TKKetQuaResponses.FromSqlRaw($"getTKKetQua {id}, {keHoachId}");
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

        [HttpGet("GetChuyenCanByLevelYourself")]
        [Authorize]
        public IActionResult GetChuyenCanByLevelYourself([FromQuery(Name = "keHoachId")] string keHoachId)
        {
            try
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                var list = _context.TKChuyenCanResponses.FromSqlRaw($"getTKChuyenCan {Int32.Parse(currentUser.FindFirst("donViId").Value)}, {keHoachId}");
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

        [HttpGet("GetChuyenCanByLevelLower/{id}")]
        [Authorize]
        public IActionResult GetChuyenCanByDonViLevelLower(int id, [FromQuery(Name = "keHoachId")] string keHoachId)
        {
            try
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
                var list = _context.TKChuyenCanResponses.FromSqlRaw($"getTKChuyenCan {id}, {keHoachId}");
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

        [HttpGet("GetKTDVByLevelLower/{id}")]
        [Authorize]
        public IActionResult GetKTDVByDonViLevelLower(int id, [FromQuery(Name = "keHoachId")] string keHoachId)
        {
            try
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
                var list = _context.TKKetQuaDVResponses.FromSqlRaw($"getTKKetQuaDV {id}");
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
    }
}
