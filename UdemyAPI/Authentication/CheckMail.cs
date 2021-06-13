using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAPI.Authentication
{
    public class CheckMail
    {
        public  class Request
        {
            //Mail To Check
            [EmailAddress]
            public string Email { set; get; }

        }
        public class Response
        {
            //EmailExistOrNot
            public bool Exists { set; get; }

        }
    }

}
