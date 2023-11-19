using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Request
{
    public class TrangThietBiRequest
    {
        public string TenTTB { get; set; }
        public int CapDo { get; set; }
        public int TinhTrang { get; set; }
        public string MoTa { get; set; }
        public string DiaDiem { get; set; }
        public int DonViId { get; set; }
    }
}
