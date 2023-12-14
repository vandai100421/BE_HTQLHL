using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Response
{
    public partial class NhanKeHoachResponse
    {
        public int Id { get; set; }
        public int? KeHoachId { get; set; }
        public int? DonViId { get; set; }
        public int? NguoiGui { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public int? NguoiSua { get; set; }
        public string? TenNguoiGui { get; set; }
        public string? DonViNhan { get; set; }
    }
}
