using System;

namespace Logic
{
    public class Service
    {
        public Response DoWork()
        {
            return new Response(){};
        }

    }

    public class Response
    {
        public bool IsSuccess { get; set; }
    }
}
