using System;
using System.Collections.Generic;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Choice
    {
        public int QuestionId { get; set; }
        public string Choices { get; set; }
    }
}
