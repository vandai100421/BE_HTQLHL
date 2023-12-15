using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Response
{
    public class ThongKeByDonViResponse
    {
        public int Id { get; set; }
        public int? DonViId { get; set; }
        public string TenDonVi { get; set; }
        public int? KeHoachId { get; set; }
        public string TenKeHoach { get; set; }
        public int? ChuyenCan { get; set; }
        public int? SoBuoiHoc { get; set; }
        public int? PhanTramKD { get; set; }
        public int? PhanTramDat { get; set; }
        public int? PhanTramKha { get; set; }
        public int? PhanTramGioi { get; set; }
        public int? PhanTramXS { get; set; }
    }
}
