using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Models
{
    public partial class NhomQuyenQuyen
    {
        public int Id { get; set; }
        public int NhomQuyenId { get; set; }
        public int QuyenId { get; set; }
    }
}
