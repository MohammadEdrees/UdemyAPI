using System;
using System.Collections.Generic;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            SupCategs = new HashSet<SupCateg>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<SupCateg> SupCategs { get; set; }
        
    }
}
