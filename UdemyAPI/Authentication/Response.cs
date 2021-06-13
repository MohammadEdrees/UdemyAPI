using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAPI.Authentication
{
    public class Response
    {
        public bool Success => Errors == null;
        public List<int> Errors { private set; get; }

        public void AddError(int error)
        {
            if (Errors == null)
                Errors = new List<int>();
            Errors.Add(error);
        }
        public void AddErrors(List<int> errors)
        {
            if (Errors == null)
                Errors = new List<int>();
            Errors.AddRange(errors);
        }
      
    }

    public class ResponseWithData<T>:Response
    {
        public T Data { set; get; }
        
    }
}
