using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAPI.Models
{
    public class SupCateg
    {
        public SupCateg()
        {
            Topics = new HashSet<Topic>();
        }
        [Key]
        public int SupCatId { set; get; }
        public string SupCatTitle{ set; get; }


        public int CategoryId { get; set; }
        public virtual Category Category { set; get; }
        public virtual ICollection<Topic> Topics { set; get; }


    }
}
