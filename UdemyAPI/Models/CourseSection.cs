using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAPI.Models
{
    public class CourseSection
    {
        public CourseSection()
        {
            CourseLecture = new HashSet<Lecture>();
        }

        [Key]
        public int SectionId { set; get; }
        public string Title { set; get; }
      //  public string LectureTitle { set; get; }

        [ForeignKey("Course")]
        public int CrsId { get; set; }
        public virtual Course Course { get; set; }

        public virtual ICollection<Lecture> CourseLecture { set; get; }




    }
}
