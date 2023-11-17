using BTLQuanLy.Data;
using BTLQuanLy.Models;
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
                var list = _context.DonVis.ToList();
                foreach (DonVi item in list)
                {
                    if (item.DonViId == null)
                    {
                        return Ok(new
                        {
                            status = "success",
                            data = item,
                        });
                    }
                }
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

        [HttpGet("list")]
        public IActionResult GetAllList([FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page)
        {
            try
            {
                var list = _context.DonViResponses.FromSqlRaw($"getAllDonVi {limit}, {page}").ToList();
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
        public IActionResult Create(DonViRequest request)
        {
            try
            {
                var result = _context.Database.ExecuteSqlRaw($"createDonVi N'{request.TenDonVi}', '{request.NgayThanhLap}', {request.DonViId}, {request.LoaiDonViId}, {request.CapDonViId}, {request.TrangThai}, 0, '{DateTime.Now}'");
                if (result == 1)
                {
                    return Ok(new
                    {
                        status = "success",
                        message = "Thêm đơn vị thành công"
                    });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, DonViRequest request)
        {
            try
            {
                var donVi = _context.DonVis.SingleOrDefault(x => x.Id == id);
                if (donVi != null)
                {
                    var result = _context.Database.ExecuteSqlRaw($"updateDonViById {id}, N'{request.TenDonVi}', '{request.NgayThanhLap}', '{request.NgayGiaiTan}', {request.DonViId}, {request.LoaiDonViId}, {request.CapDonViId}, {request.TrangThai}, 0, '{DateTime.Now}'");
                    if (result == 1)
                    {
                        return Ok(new
                        {
                            status = "success",
                            message = "Cập nhật đơn vị thành công"
                        });
                    }
                    else
                    {
                        return BadRequest();
                    }
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
                var donVi = _context.DonVis.SingleOrDefault(x => x.Id == id);
                if (donVi != null)
                {
                    var result = _context.Database.ExecuteSqlRaw($"deleteDonVi {id}");
                    if (result == 1)
                    {
                        return Ok(new
                        {
                            status = "success",
                            message = "Xóa đơn vị thành công"
                        });
                    }
                    else
                    {
                        return BadRequest();
                    }
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

        [HttpGet("search")]
        public IActionResult Search([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page)
        {
            try
            {
                var list = _context.DonViResponses.FromSqlRaw($"searchDonVi N'{q??""}', {limit}, {page}").ToList();
                return Ok(new
                {
                    status = "success",
                    data = list
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
