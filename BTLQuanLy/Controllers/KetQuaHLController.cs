using BTLQuanLy.Data;
using BTLQuanLy.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Controllers
{
    public class KetQuaHLController : Controller
    {
        private MyDbContext _context;
        public KetQuaHLController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        //[Authorize]
        public IActionResult Search([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page, [FromQuery(Name = "keHoachId")] int keHoachId)
        {
            try
            {
                var list = _context.KetQuaHLResponses.FromSqlRaw($"searchKetQua N'{q ?? ""}', {limit}, {page}, {keHoachId}").ToList();
                var total = _context.TotalKQResponses.FromSqlRaw($"getTotalKetQua N'{q ?? ""}', {limit}, {page}, {keHoachId}").ToList()[0].Total;
                return Ok(new
                {
                    status = "success",
                    data = list,
                    page,
                    limit,
                    total
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Create(KetQuaHLRequest request)
        {
            try
            {
                var result = _context.Database.ExecuteSqlRaw($"createKetQua {request.KeHoachID}, {request.HocVienId}, {request.DonViId}, {request.KetQua}, 0, '{DateTime.Now}'");
                return Ok(new
                {
                    status = "success",
                    message = "Thêm kết quả thành công"
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Update(int id, KetQuaHLRequest request)
        {
            try
            {
                var ketQua = _context.KetQuaHLs.SingleOrDefault(x => x.Id == id);
                if (ketQua != null)
                {
                    var result = _context.Database.ExecuteSqlRaw($"updateKetQua {id}, {request.KeHoachID}, {request.HocVienId}, {request.DonViId}, {request.KetQua}, 0, '{DateTime.Now}'");
                    return Ok(new
                    {
                        status = "success",
                        message = "Cập nhật kết quả thành công"
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
        //[Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                var ketQua = _context.KetQuaHLs.SingleOrDefault(x => x.Id == id);
                if (ketQua != null)
                {
                    var result = _context.Database.ExecuteSqlRaw($"deleteKetQua {id}");
                    return Ok(new
                    {
                        status = "success",
                        message = "Xóa kết quả thành công"
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
