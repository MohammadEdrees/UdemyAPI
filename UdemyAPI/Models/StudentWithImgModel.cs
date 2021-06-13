using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAPI.Models
{
    public class StudentWithImgModel
    {
        public Student Student { get; set; }
        public IFormFile image { get; set; }
    }
}
