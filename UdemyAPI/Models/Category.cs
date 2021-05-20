using System;
using System.Collections.Generic;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            Topics = new HashSet<Topic>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}
