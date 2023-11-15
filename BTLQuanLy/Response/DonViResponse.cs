using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Response
{
    public class DonViResponse
    {
        public int Id { get; set; }
        public string TenDonVi { get; set; }
        public DateTime? NgayThanhLap { get; set; }
        public DateTime? NgayGiaiTan { get; set; }
        public int? DonViId { get; set; }
        public int? LoaiDonViId { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public int? NguoiSua { get; set; }
        public string TenLoaiDv { get; set; }
    }
}
