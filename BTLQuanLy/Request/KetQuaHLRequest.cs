using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Request
{
    public class KetQuaHLRequest
    {
        public int Id { get; set; }
        public int? KeHoachID { get; set; }
        public int? HocVienId { get; set; }
        public int? DonViId { get; set; }
        //0: không đat, 1: đạt, 2: khá, 3: giỏi
        public int? KetQua { get; set; }
    }
}
