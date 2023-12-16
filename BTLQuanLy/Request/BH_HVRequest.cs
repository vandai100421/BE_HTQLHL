using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Request
{
    public class BH_HVRequest
    {
        public int? KeHoachId { get; set; }
        public List<Detail> Details { get; set; }
    }

    public class Detail
    {
        public int? BH_HVId { get; set; }
        public int? CoMat { get; set; }
    }
}
