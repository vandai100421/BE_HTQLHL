using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Request
{
    public partial class HocVienRequest
    {
        public string MaHocVien { get; set; }
        public string TenHocVien { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
        public int? DonViId { get; set; }
        public string QueQuan { get; set; }
        public string SoDienThoai { get; set; }
    }
}
