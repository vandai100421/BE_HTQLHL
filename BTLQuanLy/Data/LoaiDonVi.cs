using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Data
{
    [Table("LoaiDonVi")]
    public partial class LoaiDonVi
    {
        [Key]
        [Column("IDLoaiDV")]
        public int IdloaiDv { get; set; }
        [Column("TenLoaiDV")]
        [StringLength(50)]
        public string TenLoaiDv { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgaySua { get; set; }
        public int? NguoiSua { get; set; }
    }
}
