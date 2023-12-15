using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Models
{
    public partial class BuoiHoc
    {
        public int Id { get; set; }
        public int? KeHoachId { get; set; }
        public DateTime? ThoiGian { get; set; }
        public int? ThuTu { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public int? NguoiSua { get; set; }
    }
}
