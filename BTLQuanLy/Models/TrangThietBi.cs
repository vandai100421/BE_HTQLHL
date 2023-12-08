using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Models
{
    public partial class TrangThietBi
    {
        public int Id { get; set; }
        public string TenTTB { get; set; }
        public int? CapDo { get; set; }
        public int? TinhTrang { get; set; }
        public string MoTa { get; set; }
        public string DiaDiem { get; set; }
        public int? DonViId { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public int? NguoiSua { get; set; }
    }
}
