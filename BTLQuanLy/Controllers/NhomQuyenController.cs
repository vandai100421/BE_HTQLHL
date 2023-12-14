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
    public class NhomQuyenController : ControllerBase
    {
        private MyDbContext _context;
        public NhomQuyenController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult GetAll()
        {
            try
            {
                var list = _context.NhomQuyens.ToList();
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
        public IActionResult Create(NhomQuyenRequest request)
        {
            try
            {
                var nhomQuyen = new NhomQuyen
                {
                    TenNhomQuyen = request.TenNhomQuyen
                };
                _context.NhomQuyens.Add(nhomQuyen);
                _context.SaveChanges();
                return Ok(new
                {
                    status = "success",
                    message = "Thêm nhóm quyền thành công"
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
