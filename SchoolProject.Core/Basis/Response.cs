using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Basis
{
    public class Response<T>
    {
        public Response()
        {
            
        }

        public Response(string message)
        {
            Message = message;
            Succeeded = false;
        }

        public Response(T data, string message = null)
        {
            Message = message;
            Data = data;
            Succeeded = true;
        }

        public Response(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public HttpStatusCode StatusCode { get; set; }
        public object Meta { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
