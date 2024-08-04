using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class Response<T>
    {
        public bool Succeeded { get; set; }
        public bool Failure { get; set; }
        public string Message { get;set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public Response() { }

        public Response(T data, string message = null)
        {
            Succeeded = true;
            Failure = false;
            Message = message;
            Data = data;
        }

        public Response(string message)
        {
            Succeeded = false;
            Failure = true;
            Message = message;
        }

        public Response(List<string> errors, string message)
        {
            Succeeded = false;
            Failure = true;
            Errors = errors;
            Message = message;
        }
    }
}
