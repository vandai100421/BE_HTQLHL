using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Models
{
    public partial class NhomNguoiDung
    {
        public int Id { get; set; }
        public string TenNhomND { get; set; }
        public int NhomQuyenId { get; set; }
    }
}
