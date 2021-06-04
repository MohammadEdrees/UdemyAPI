using System;
using System.Collections.Generic;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class InstCr
    {
        
        public int InstId { get; set; }
        public int CrsId { get; set; }

        public virtual Instructor Instructor { get; set; }

        public virtual Course Course { get; set; }
    }
}
