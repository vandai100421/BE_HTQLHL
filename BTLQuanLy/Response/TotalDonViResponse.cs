using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTLQuanLy.Response
{
    public class TotalDonViResponse
    {
        public int Id { get; set; }
        public int Total { get; set; }
    }
}
