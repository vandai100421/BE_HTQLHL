using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Models
{
    public partial class HV_TTB
    {
        public int Id { get; set; }
        public int? HocVienId { get; set; }
        public int? TTBId { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public int? NguoiSua { get; set; }
    }
}
