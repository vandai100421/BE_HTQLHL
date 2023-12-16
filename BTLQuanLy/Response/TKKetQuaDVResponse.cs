using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Response
{
    public class TKKetQuaDVResponse
    {
        public int Id { get; set; }
        public int? DonViId { get; set; }
        public string TenDonVi { get; set; }
        public int? KeHoachId { get; set; }
        public string TenKeHoach { get; set; }
        public int? SLKhongDat { get; set; }
        public int? SLDat { get; set; }
        public int? SLGioi { get; set; }
        public int? SLXuatSac { get; set; }
        public int? SLThamGia { get; set; }
    }
}
