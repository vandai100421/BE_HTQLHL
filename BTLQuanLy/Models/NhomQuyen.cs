using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Models
{
    public partial class NhomQuyen
    {
        public int Id { get; set; }
        public string TenNhomQuyen { get; set; }
    }
}
