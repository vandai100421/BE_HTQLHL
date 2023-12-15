using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Request
{
    public class BuoiHocRequest
    {
        public int Id { get; set; }
        public int? KeHoachId { get; set; }
        public DateTime? ThoiGian { get; set; }
        public int? ThuTu { get; set; }
    }
}
