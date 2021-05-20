using System;
using System.Collections.Generic;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class StdCr
    {
        public int StdId { get; set; }
        public int CrsId { get; set; }
        public int? Grade { get; set; }
        public string Certificate { get; set; }
    }
}
