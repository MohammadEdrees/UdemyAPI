using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Instructor
    {
        public int InstId { get; set; }

        [MaxLength(50,ErrorMessage = "Can't Exceed 50 character")]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^(.{0,7}|[^0-9]*|[^A-Z])$",
        ErrorMessage = "Error, 8 characters, at least one letter and one number")]
        public string Password { get; set; }

        public string ImagPath { get; set; }

        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Not Valid Email")]

        public string Mail { get; set; }

        [MaxLength(30, ErrorMessage = "Can't Exceed 30 character")]
        public string Communication { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Your Name can't be more less than 5 and more than 15")]
        public string Fname { get; set; }

        [MaxLength(50, ErrorMessage = "Can't Exceed 50 character")]
        public string Lname { get; set; }

        [MaxLength(30, ErrorMessage = "Can't Exceed 30 character")]
        public string Language { get; set; }
        [MaxLength(50, ErrorMessage = "Can't Exceed 50 character")]
        public string HeadLine { get; set; }
       
        [MaxLength(100, ErrorMessage = "Can't Exceed 100 character")]
        public string Biography { get; set; }
    }
}
