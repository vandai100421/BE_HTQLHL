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
    public class HocVienController : ControllerBase
    {
        private MyDbContext _context;
        public HocVienController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var list = _context.HocViens.FromSqlRaw("getAllHocVien").ToList();
                return Ok(list);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(HocVien model)
        {
            try
            {
                model.NgayTao = DateTime.Now;
                _context.Add(model);
                _context.SaveChanges();
                return Ok(new
                {
                    status = "success",
                    data = model,
                    message = "Thêm học viên thành công"
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, HocVienModel model)
        {
            try
            {
                var hocVien = _context.HocViens.SingleOrDefault(x => x.IdhocVien == id);
                if (hocVien != null)
                {
                    hocVien.TenHocVien = model.TenHocVien;
                    hocVien.GioiTinh = model.GioiTinh;
                    hocVien.NgaySinh = model.NgaySinh;
                    hocVien.QueQuan = model.QueQuan;
                    hocVien.SoDienThoai = model.SoDienThoai;
                    hocVien.IddonVi = model.IddonVi;
                    hocVien.NgaySua = DateTime.Now;
                    _context.SaveChanges();
                    return Ok(new
                    {
                        status = "success",
                        message = "Cập nhật học viên thành công"
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
                var hocVien = _context.HocViens.SingleOrDefault(x => x.IdhocVien == id);
                if (hocVien != null)
                {
                    _context.Remove(hocVien);
                    _context.SaveChanges();
                    return Ok(new
                    {
                        status = "success",
                        message = "Xóa học viên thành công"
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
