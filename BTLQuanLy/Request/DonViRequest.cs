using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Request
{
    public class DonViRequest
    {
        public string TenDonVi { get; set; }
        public DateTime? NgayThanhLap { get; set; }
        public DateTime? NgayGiaiTan { get; set; }
        public int? DonViId { get; set; }
        public int? LoaiDonViId { get; set; }
        public int? TrangThai { get; set; }
    }
}
