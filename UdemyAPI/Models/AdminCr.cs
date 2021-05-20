using System;
using System.Collections.Generic;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class AdminCr
    {
        public int AdminId { get; set; }
        public int CrsId { get; set; }
        public string Manage { get; set; }
    }
}
