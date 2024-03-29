﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Models
{
    public partial class NguoiDung
    {
        public int Id { get; set; }
        public string TenNguoiDung { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        //1: Admin, 2: đơn vị
        public int? VaiTro { get; set; }
        public int? DonViId { get; set; }
        public string MatKhau { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public int? NguoiSua { get; set; }
    }
}
