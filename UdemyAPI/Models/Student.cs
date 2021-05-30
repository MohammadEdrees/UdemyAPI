using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentCourses = new HashSet<StdCr>();

        }
        public int StdId { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Your Name can't be more less than 5 and more than 15")]
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Phone { get; set; }
        public string ImagePath { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
        @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
        @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Not Valid Email")]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
        public string Address { get; set; }
        public virtual ICollection<StdCr> StudentCourses { set; get; }

    }
}
