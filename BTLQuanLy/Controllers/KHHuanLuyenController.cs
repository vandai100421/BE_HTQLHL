﻿using BTLQuanLy.Data;
using BTLQuanLy.Models;
using BTLQuanLy.Request;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KHHuanLuyenController : ControllerBase
    {
        private MyDbContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        public KHHuanLuyenController(MyDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery(Name = "q")] string q, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "page")] int page)
        {
            var list = _context.KHHuanLuyenResponses.FromSqlRaw($"searchKeHoach N'{q ?? ""}', {limit}, {page}").ToList();
            return Ok(new
            {
                status = "success",
                data = list,
            });
        }

        [HttpPost]
        public IActionResult Create([FromForm]KHHuanLuyenRequest request)
        {
            try
            {
                var keHoach = new KHHuanLuyen();
                keHoach.TenKeHoach = request.TenKeHoach;
                keHoach.NguoiGui = 0;
                keHoach.NguoiTao = 0;
                keHoach.NgayTao = DateTime.Now;
                _context.Add(keHoach);
                foreach(var item in request.DonViIds)
                {
                    var nhanKeHoach = new NhanKeHoach();
                    nhanKeHoach.KeHoachId = keHoach.Id;
                    nhanKeHoach.DonViId = item;
                    nhanKeHoach.NguoiTao = 0;
                    nhanKeHoach.NgayTao = DateTime.Now;
                    _context.Add(nhanKeHoach);
                }
                _context.SaveChanges();
                if (request.Link.Length > 0)
                {
                    using(FileStream filestream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\public\\" + request.Link.FileName))
                    {
                        request.Link.CopyTo(filestream);

                    }
                }
                return Ok(new
                {
                    status = "success",
                    message = "Thêm kế hoạch thành công",
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, KHHuanLuyenRequest request)
        {
            try
            {
                var keHoach = _context.KHHuanLuyens.SingleOrDefault(x => x.Id == id);
                if (keHoach != null)
                {
                    keHoach.TenKeHoach = request.TenKeHoach;
                    keHoach.NguoiGui = 0;
                    keHoach.NguoiSua = 0;
                    keHoach.NgaySua = DateTime.Now;
                    _context.SaveChanges();
                    return Ok(new
                    {
                        status = "success",
                        message = "Cập nhật kế hoạch thành công",
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
                var keHoach = _context.KHHuanLuyens.SingleOrDefault(x => x.Id == id);
                if (keHoach != null)
                {
                    _context.Remove(keHoach);
                    _context.SaveChanges();
                    return Ok(new
                    {
                        status = "success",
                        message = "Xóa kế hoạch thành công"
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