using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Response
{
    public partial class BH_HVResponse
    {
        public int Id { get; set; }
        public int? BuoiHocId { get; set; }
        public int? HocVienId { get; set; }
        public string TenHocVien { get; set; }
        public int? CoMat { get; set; }
        public int? DonViId { get; set; }
    }
}
