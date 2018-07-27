using System;

namespace Logic
{
    public class Service
    {
        public Response SomeServiceCall(Func<Response> codeToExecute)
        {
            return codeToExecute();
        }
    }
    public class Response
    {
        public bool IsSuccess { get; set; }
    }
}
