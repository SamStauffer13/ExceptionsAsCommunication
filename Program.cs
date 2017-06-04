using System;
using System.Diagnostics;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numberOfLoops = 1000000;
            var timer = new Stopwatch();

            timer.Start();
            for (var i = 0; i < numberOfLoops; i++)
            {
                try
                {
                    var resonse = UsesExceptionsToCommunicateError();
                }
                catch (Exception e)
                {
                    ErrorHandling();
                }
            }
            timer.Stop();
            Console.WriteLine($"Execution time with Exceptions: {timer.Elapsed}");

            timer.Start();
            for (var i = 0; i < numberOfLoops; i++)
            {
                var response = UsesResponseObjectToCommunicateError();

                if (response.WasSucessful == false)
                {
                    ErrorHandling();
                }
            }
            timer.Stop();
            Console.WriteLine($"Execution time with Checking Response Object: {timer.Elapsed}");

            timer.Start();
            for (var i = 0; i < numberOfLoops; i++)
            {
                var response = UsesNullToCommunicateError();

                if (response == null)
                {
                    ErrorHandling();
                }
            }
            timer.Stop();
            Console.WriteLine($"Execution time with Null Check: {timer.Elapsed}");
        }
        private static ResponseObject UsesExceptionsToCommunicateError()
        {
            throw new Exception();
        }

        private static ResponseObject UsesResponseObjectToCommunicateError()
        {
            return new ResponseObject()
            {
                WasSucessful = false
            };
        }

        private static ResponseObject UsesNullToCommunicateError()
        {
            return null;
        }

        private static void ErrorHandling()
        {

        }
    }

    public class ResponseObject
    {
        public bool WasSucessful { get; set; }
    }
}
