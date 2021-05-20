using System;
using System.Collections.Generic;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Student
    {
        public int StdId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Phone { get; set; }
        public string ImagePath { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }
}
