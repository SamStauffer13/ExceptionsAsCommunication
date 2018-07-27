using System;

namespace Logic
{
    public delegate Response DoWork();

    public class Service
    {
        public Response SomeServiceCall(DoWork codeToExecute)
        {
            return codeToExecute();
        }
    }
    public class Response
    {
        public bool IsSuccess { get; set; }
    }
}
