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
        public string TenKeHoach { get; set; }
        public string Link { get; set; }
        public int? NguoiGui { get; set; }
        public string TenNguoiGui { get; set; }
    }
}
