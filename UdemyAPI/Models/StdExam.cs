using System;
using System.Collections.Generic;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class StdExam
    {
        public int StdId { get; set; }
        public int QuestionId { get; set; }
        public int ExamId { get; set; }
        public string StdAnswer { get; set; }
    }
}
