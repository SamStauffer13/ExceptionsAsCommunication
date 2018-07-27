using System;

namespace Logic
{
    public delegate Response DoWork();

    public class Service
    {
        public Response SomeServiceCall(DoWork codeToExecute)
        {
            return new Response(){};
        }

    }

    public class Response
    {
        public bool IsSuccess { get; set; }
    }
}
