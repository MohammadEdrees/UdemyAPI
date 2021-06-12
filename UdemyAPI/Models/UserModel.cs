using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAPI.Models
{
    public class UserModel
    {
        [Required]
        [EmailAddress]
        public string Mail { set; get; }
        [Required]
        public string Password { set; get; }
    }
}
