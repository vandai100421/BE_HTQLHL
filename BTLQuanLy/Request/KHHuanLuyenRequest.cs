using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Request
{
    public class KHHuanLuyenRequest
    {
        public string TenKeHoach { get; set; }
        public IFormFile Link { get; set; }
        public string NoiDung { get; set; }
        public int? DonViId { get; set; }
        public int? SoBuoiHoc { get; set; }
        public int? SoGio { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
    }
}
