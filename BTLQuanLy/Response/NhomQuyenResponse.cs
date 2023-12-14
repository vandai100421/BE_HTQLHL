using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Response
{
    public class NhomQuyenResponse
    {
        public int Id { get; set; }
        public string TenNhomQuyen { get; set; }
    }
}
