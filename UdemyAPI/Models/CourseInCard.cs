using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAPI.Models
{
    public class CourseInCard
    {
        [ForeignKey("Course")]
        public int CrsId { get; set; }
        [ForeignKey("Card")]

        public int CId { set; get; }

        public virtual Course Course { set; get; }
        public virtual Card Card { set; get; }

    }
}
