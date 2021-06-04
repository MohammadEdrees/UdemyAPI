using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAPI.Models
{
    public class ShoppingCard
    {
        public ShoppingCard()
        {
            Courses = new HashSet<Course>();
        }
        [Key]     
        public int CardId { set; get; }
        [ForeignKey("Student")]
        public int? StdId { get; set; }
        [ForeignKey("Instructor")]
        public int? InstId { get; set; }

        public virtual Student Student { set; get; }
        public virtual Instructor Instructor { set; get; }
        public virtual ICollection<Course> Courses { set; get; }


    }
}
