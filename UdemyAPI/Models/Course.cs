using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Course
    {
        public Course()
        {
            studentCourses = new HashSet<StdCr>();
            CourseSections = new HashSet<CourseSection>();
            CourseInCards = new HashSet<CourseInCard>();
            // CourseVideos = new HashSet<Video>();
        }
        [Key]
        public int CrsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public int PaymentMethod { get; set; }
        public string Languge { get; set; }
        public string Levels { get; set; }
        public string Subtitle { get; set; }
      //  public string Author { get; set; }
        public string ImagePath { get; set; }
        public double Rate { get; set; }
        public string State { get; set; }

        [Column(Order = 0)]
        [ForeignKey("Top")]

        public int? TopId { get; set; }
        public virtual Topic Top { get; set; }

        public virtual ICollection<StdCr> studentCourses { set; get; }
        public virtual ICollection<CourseSection> CourseSections { set; get; }
        public virtual ICollection<CourseInCard> CourseInCards { set; get; }

       // [Column(Order = 1)]
       // [ForeignKey("ShoppingCard")]

       //public int? CardId { set; get; }
       // public virtual ShoppingCard ShoppingCard { set; get; }

        [Column(Order = 1)]
        [ForeignKey("Instructor")]
        public int InstId { get; set; }

        public virtual Instructor Instructor { set; get; }

        public double? Price { set; get; }
        [Column(Order = 2)]
        [ForeignKey("Card")]
        public int? CId { set; get; }

        public virtual Card Card { set; get; }




    }
}
