using BTLQuanLy.Data;
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

        [HttpGet("GetByDonViLevelYourself/{id}")]
        //[Authorize]
        public IActionResult GetByDonViLevelYourself(int id, [FromQuery(Name = "keHoachId")] string keHoachId)
        {
            try
            {
                var list = _context.ThongKeByDonViResponses.FromSqlRaw($"getTKByDonViCapMinh {id}, {keHoachId}");
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

        [HttpGet("GetByDonViLevelLower/{id}")]
        //[Authorize]
        public IActionResult GetByDonViLevelLower(int id, [FromQuery(Name = "keHoachId")] string keHoachId)
        {
            try
            {
                var list = _context.ThongKeByDonViResponses.FromSqlRaw($"getTKByDonViCapDuoi {id}, {keHoachId}");
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

        [HttpGet("GetHocVienByDonViLevelYourself/{id}")]
        //[Authorize]
        public IActionResult GetHocVienByDonViLevelYourself(int id, [FromQuery(Name = "keHoachId")] string keHoachId)
        {
            try
            {
                var list = _context.ThongKeByHocVienResponses.FromSqlRaw($"getTKKQHocVienCapMinh {id}, {keHoachId}");
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

        [HttpGet("GetHocVienByDonViLevelLower/{id}")]
        //[Authorize]
        public IActionResult GetHocVienByDonViLevelLower(int id, [FromQuery(Name = "keHoachId")] string keHoachId)
        {
            try
            {
                var list = _context.ThongKeByDonViResponses.FromSqlRaw($"getTKKQHocVienCapDuoi {id}, {keHoachId}");
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
