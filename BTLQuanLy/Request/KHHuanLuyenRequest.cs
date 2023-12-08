using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Request
{
    public class KHHuanLuyenRequest
    {
        public string TenKeHoach { get; set; }
        public IFormFile Link { get; set; }
        public int NguoiGui { get; set; }
        public List<int> DonViIds { get; set; }
    }
}
