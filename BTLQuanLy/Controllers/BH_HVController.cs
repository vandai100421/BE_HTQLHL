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
    public class BH_HVController : ControllerBase
    {
        private MyDbContext _context;
        public BH_HVController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllByKHId/{id}")]
        //[Authorize]
        public IActionResult GetAllByKHId(int id)
        {
            var keHoach = _context.KHHuanLuyens.SingleOrDefault(x => x.Id == id);
            var list = _context.BH_HVResponses.FromSqlRaw($"getBH_HVByKHId {id}").ToList();
            return Ok(new
            {
                status = "success",
                data = new
                {
                    soBuoiHoc = keHoach.SoBuoiHoc,
                    detail = list,
                }
            });
        }
    }
}
