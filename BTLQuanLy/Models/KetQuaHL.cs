using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Models
{
    public partial class KetQuaHL
    {
        public int Id { get; set; }
        public int? KeHoachID { get; set; }
        public int? HocVienId { get; set; }
        public int? DonViId { get; set; }
        //0: không đat, 1: đạt, 2: khá, 3: giỏi
        public int? KetQua { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public int? NguoiSua { get; set; }
    }
}
