using System;
using System.Collections.Generic;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Topic
    {
        public Topic()
        {
            Courses = new HashSet<Course>();
        }

        public int TopId { get; set; }
        public string TopName { get; set; }
        public int CategId { get; set; }

        public virtual Category Categ { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
