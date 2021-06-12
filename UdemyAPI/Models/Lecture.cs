using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Lecture
    {
        public int LectureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Duration { get; set; }
        public string Link { set; get; }

        [ForeignKey("CourseSection")]
        public int SectionId { get; set; }
         public virtual CourseSection CourseSection { set; get; }
    }
}
