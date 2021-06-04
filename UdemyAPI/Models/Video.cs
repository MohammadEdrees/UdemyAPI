using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class Video
    {
        public int VidId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        [ForeignKey("Course")]
        public int CrsId { get; set; }
        public virtual Course Course { set; get; }
    }
}
