using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BTLQuanLy.Response
{
    public partial class KetQuaHLResponse
    {
        public int Id { get; set; }
        public int? KeHoachId { get; set; }
        public int? HocVienId { get; set; }
        //0: không đat, 1: đạt, 2: khá, 3: giỏi
        public int? KetQua { get; set; }
    }
}
