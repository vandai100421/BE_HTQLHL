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
    public class QuyenController : ControllerBase
    {
        private MyDbContext _context;
        public QuyenController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult GetAll()
        {
            try
            {
                var list = _context.Quyens.ToList();
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
        public IActionResult Create(QuyenRequest request)
        {
            try
            {
                var quyen = new Quyen
                {
                    TenQuyen = request.TenQuyen
                };
                _context.Quyens.Add(quyen);
                _context.SaveChanges();
                return Ok(new
                {
                    status = "success",
                    message = "Thêm quyền thành công"
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
