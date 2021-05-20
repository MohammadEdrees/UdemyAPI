using System;
using System.Collections.Generic;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Exam
    {
        public int ExmId { get; set; }
        public int CrsId { get; set; }
        public string ExamName { get; set; }
    }
}
