using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Data
{
    [Table("HocVien")]
    public partial class HocVien
    {
        [Key]
        [Column("IDHocVien")]
        public int IdhocVien { get; set; }
        [StringLength(10)]
        public string MaHocVien { get; set; }
        [StringLength(40)]
        public string TenHocVien { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
        [StringLength(100)]
        public string QueQuan { get; set; }
        [StringLength(10)]
        public string SoDienThoai { get; set; }
        [Column("IDDonVi")]
        public int? IddonVi { get; set; }
        [Column(TypeName = "datetime")]

        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgaySua { get; set; }
        public int? NguoiSua { get; set; }
    }
}
