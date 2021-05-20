using System;
using System.Collections.Generic;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Instructor
    {
        public int InstId { get; set; }
        public string InstName { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string ImagPath { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
    }
}
