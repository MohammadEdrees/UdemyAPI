using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAPI.Authentication
{
    public class SignUp
    {
        public class request
        {
            [Required]
            [EmailAddress]
            public string Email { set; get; }

            [Required]
            [MinLength(8)]
            [MaxLength(20)]
            public string Password { set; get; }
        }
        public class response
        {
            public string Email { get; set; }
            public string Token { get; set; }
            public string Password { get; set; }
        }
      
    }
}
