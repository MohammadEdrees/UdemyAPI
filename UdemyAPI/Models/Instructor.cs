using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Instructor
    {
        public int InstId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string HeadLine { get; set; }
        public string Biography { get; set; }
        public string Password { get; set; }
        public string ImagPath { get; set; }
  
        public string Communication { get; set; }
        public string Mail { get; set; }
        public string Language { get; set; }
    }
}
