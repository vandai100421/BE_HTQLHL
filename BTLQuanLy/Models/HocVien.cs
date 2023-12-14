using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Models
{
    public partial class HocVien
    {
        public int Id { get; set; }
        public string MaHocVien { get; set; }
        public string TenHocVien { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
        public int? KhoaHoc { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public int? LoaiHocVien { get; set; }
        public string QueQuan { get; set; }
        public string SoDienThoai { get; set; }
        public int? CapBacId { get; set; }
        public int? ChucVuId { get; set; }
        public int? DonViId { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public int? NguoiSua { get; set; }
    }
}
