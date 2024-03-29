﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Models
{
    public partial class KHHuanLuyen
    {
        public int Id { get; set; }
        public string MaKeHoach { get; set; }
        public string TenKeHoach { get; set; }
        //public string Link { get; set; }
        public string NoiDung { get; set; }
        public int? DonViId { get; set; }
        public int? SoBuoiHoc { get; set; }
        public int? SoTiet { get; set; }
        public int? DaTaoBH { get; set; }
        public int? DaTaoKQ { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public int? NguoiSua { get; set; }
    }
}
