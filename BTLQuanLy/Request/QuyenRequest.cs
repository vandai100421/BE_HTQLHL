using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Request
{
    public class QuyenRequest
    {
        public int Id { get; set; }
        public string TenQuyen { get; set; }
    }
}
