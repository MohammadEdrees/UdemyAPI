using System;
using System.Collections.Generic;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            //Topics = new HashSet<Topic>();
            SupCategs = new HashSet<SupCateg>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

       // public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<SupCateg> SupCategs { get; set; }
        
    }
}
