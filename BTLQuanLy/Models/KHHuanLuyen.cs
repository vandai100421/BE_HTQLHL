using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Models
{
    public partial class KHHuanLuyen
    {
        public int Id { get; set; }
        public string TenKeHoach { get; set; }
        public string Link { get; set; }
        public string MoTa { get; set; }
        public int NguoiLap { get; set; }
        public DateTime? NgayApDung { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public int? NguoiSua { get; set; }
    }
}
