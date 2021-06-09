using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAPI.Models
{
    public class VideoStream
    {
        private readonly string FileName;

        public VideoStream(string _fileName)
        {
            FileName = _fileName;
        }
        public async void WriteToStream(Stream outputStream) { }
        
    }
}
