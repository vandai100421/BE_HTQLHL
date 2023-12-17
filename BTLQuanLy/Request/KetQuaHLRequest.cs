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
        public int? KeHoachID { get; set; }
        public List<DetailKQ> Details { get; set; }
    }

    public class DetailKQ
    {
        public int? KetQuaId { get; set; }
        //0: không đat, 1: đạt, 2: khá, 3: giỏi
        public int? KetQua { get; set; }
    }
}
