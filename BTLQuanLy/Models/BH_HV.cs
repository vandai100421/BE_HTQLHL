using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Models
{
    public partial class BH_HV
    {
        public int Id { get; set; }
        public int? BuoiHocId { get; set; }
        public int? HocVienId { get; set; }
        public int? CoMat { get; set; }
        public int? DonViId { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public int? NguoiSua { get; set; }
    }
}
