using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Models
{
    public class DonViModel
    {
        [Key]
        [Column("IDDonVi")]
        public int IddonVi { get; set; }
        [StringLength(50)]
        public string TenDonVi { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayThanhLap { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayGiaiTan { get; set; }
        [Column("IDLoaiDV")]
        public int? IdloaiDv { get; set; }
        [Column("IDDonViCha")]
        public int? IddonViCha { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgaySua { get; set; }
        public int? NguoiSua { get; set; }
        [Column("TenLoaiDV")]
        [StringLength(50)]
        public string TenLoaiDv { get; set; }
    }
}
