using System;

namespace Logic
{
    public class Service
    {
        public int NumberOfExecutions = 0;
        public Response SomeServiceCall(Func<Response> codeToExecute, int numberOfExecutionsToPerform)
        {
            if (NumberOfExecutions == numberOfExecutionsToPerform) return codeToExecute();

            NumberOfExecutions++;

            return SomeServiceCall(codeToExecute, numberOfExecutionsToPerform);
        }
    }
    public class Response
    {
        public bool ThereWasAnError { get; set; }
    }
}
