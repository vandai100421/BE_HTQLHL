using BTLQuanLy.Data;
using BTLQuanLy.Models;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var list = _context.DonViModels.FromSqlRaw("getAllDonVi").ToList();
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
        public IActionResult Create(DonVi model)
        {
            try
            {
                model.NgayTao = DateTime.Now;
                _context.Add(model);
                _context.SaveChanges();
                return Ok(new { 
                    status= "success",
                    data= model,
                    message = "Thêm đơn vị thành công"
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, DonVi model)
        {
            try
            {
                var donVi = _context.DonVis.SingleOrDefault(x => x.IddonVi == id);
                if (donVi != null)
                {
                    donVi.TenDonVi = model.TenDonVi;
                    donVi.NgayThanhLap = model.NgayThanhLap;
                    donVi.IddonViCha = model.IddonViCha;
                    donVi.IdloaiDv = model.IdloaiDv;
                    donVi.NgaySua = DateTime.Now;
                    _context.SaveChanges();
                    return Ok(new {
                        status = "success",
                        message = "Cập nhật đơn vị thành công"
                    });
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
        public IActionResult Delete(int id)
        {
            try
            {
                var donVi = _context.DonVis.SingleOrDefault(x => x.IddonVi == id);
                if (donVi != null)
                {
                    _context.Remove(donVi);
                    _context.SaveChanges();
                    return Ok(new
                    {
                        status = "success",
                        message = "Xóa đơn vị thành công"
                    });
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
    }
}
