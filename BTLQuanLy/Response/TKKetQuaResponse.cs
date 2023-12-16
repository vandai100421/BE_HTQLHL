﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Response
{
    public class TKKetQuaResponse
    {
        public int Id { get; set; }
        public int? DonViId { get; set; }
        public string TenDonVi { get; set; }
        public int? HocVienId { get; set; }
        public string TenHocVien { get; set; }
        public int? KetQua { get; set; }
    }
}
