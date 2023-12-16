using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Response
{
    public partial class KHHuanLuyenResponse
    {
        public int Id { get; set; }
        public int MaKeHoach { get; set; }
        public string TenKeHoach { get; set; }
        public string Link { get; set; }
        public string NoiDung { get; set; }
        public string TenNguoiLap { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public int? DaTaoBH { get; set; }
        public int? DaTaoKQ { get; set; }
    }
}
