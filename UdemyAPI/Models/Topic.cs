using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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


        public int SupCatId { set; get; }

        public virtual SupCateg supCateg { set; get; }

        //public int CategId { get; set; }

        // public virtual Category Categ { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
