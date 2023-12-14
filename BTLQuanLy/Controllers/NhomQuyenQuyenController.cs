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
    public class NhomQuyenQuyenController : ControllerBase
    {
        private MyDbContext _context;
        public NhomQuyenQuyenController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult GetAll()
        {
            try
            {
                var list = _context.NhomQuyenQuyens.ToList();
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
        public IActionResult Create(NhomQuyenQuyenRequest request)
        {
            try
            {
                var nhomQuyenQuyen = new NhomQuyenQuyen
                {
                    NhomQuyenId = request.NhomQuyenId,
                    QuyenId = request.QuyenId
                };
                _context.NhomQuyenQuyens.Add(nhomQuyenQuyen);
                _context.SaveChanges();
                return Ok(new
                {
                    status = "success",
                    message = "Thêm nhóm quyền quyền thành công"
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
