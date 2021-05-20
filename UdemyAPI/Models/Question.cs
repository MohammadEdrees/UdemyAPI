using System;
using System.Collections.Generic;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public string Formula { get; set; }
        public string Answer { get; set; }
        public int Degree { get; set; }
        public string Type { get; set; }
    }
}
