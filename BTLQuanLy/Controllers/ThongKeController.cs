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

        [HttpGet("GetChuyenCanByLevelLower")]
        [Authorize]
        public IActionResult GetChuyenCanByDonViLevelLower()
        {
            try
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                var list = _context.TKChuyenCanResponses.FromSqlRaw($"getTKChuyenCan {Int32.Parse(currentUser.FindFirst("donViId").Value)}");
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

        [HttpGet("GetKTDVByLevelLower")]
        [Authorize]
        public IActionResult GetKTDVByDonViLevelLower()
        {
            try
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                var list = _context.TKKetQuaDVResponses.FromSqlRaw($"getTKKetQuaDV {Int32.Parse(currentUser.FindFirst("donViId").Value)}");
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
