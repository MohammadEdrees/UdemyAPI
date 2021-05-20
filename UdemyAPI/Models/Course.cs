using System;
using System.Collections.Generic;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Course
    {
        public int CrsId { get; set; }
        public string CrsName { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public int? PaymentMethod { get; set; }
        public int TopId { get; set; }

        public virtual Topic Top { get; set; }
    }
}
