using BTLQuanLy.Data;
using BTLQuanLy.Models;
using BTLQuanLy.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhomNDController : ControllerBase
    {
        private MyDbContext _context;
        public NhomNDController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult GetAll()
        {
            try
            {
                var list = _context.NhomNguoiDungs.ToList();
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

        [HttpPost]
        //[Authorize]
        public IActionResult Create(NhomNDRequest request)
        {
            try
            {
                var nhomNguoiDung = new NhomNguoiDung
                {
                    TenNhomND = request.TenNhomND
                };
                _context.NhomNguoiDungs.Add(nhomNguoiDung);
                _context.SaveChanges();
                return Ok(new
                {
                    status = "success",
                    message = "Thêm nhóm người dùng thành công"
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
