using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Course
    {
        public int CrsId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public string Duration { get; set; }
        public int? PaymentMethod { get; set; }
        public int TopId { get; set; }
        public virtual Topic Top { get; set; }
        public string Languge { get; set; }
        public string Level { get; set; }
        
    }
}
