using BTLQuanLy.Data;
using BTLQuanLy.Request;
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

        [HttpPut]
        //[Authorize]
        public IActionResult Update(BuoiHocRequest request)
        {
            try
            {
                var result = _context.Database.ExecuteSqlRaw($"updateBuoiHoc {request.KeHoachId}, '{request.ThoiGian}', {request.ThuTu}, '{DateTime.Now}', 0");
                return Ok(new
                {
                    status = "success",
                    message = "Cập nhật buổi học thành công",
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAllByKHId/{id}")]
        //[Authorize]
        public IActionResult GetAllByKHId(int id)
        {
            try
            {
                var list = _context.BuoiHocs.Where(x=>x.KeHoachId==id).ToList();
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
        //[Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _context.Database.ExecuteSqlRaw($"deleteBuoiHoc {id}");
                return Ok(new
                {
                    status = "success",
                    message = "Xóa buổi học thành công",
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
