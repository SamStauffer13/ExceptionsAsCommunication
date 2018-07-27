using Xunit;
using Logic;
using System;
using System.Diagnostics;

namespace Logic.Tests
{
    public class ServiceTests  // cd to this dir then run dotnet test in terminal
    {
        [Fact]
        public void NumberOfExecutionsCanBeControlled()
        {
            var service = new Service();

            var expectedNumberOfExecutions = 7;

            var response = service.SomeServiceCall(() =>
            {
                return new Response();

            }, expectedNumberOfExecutions);

            Assert.Equal(expectedNumberOfExecutions, service.NumberOfExecutions);
        }

        [Fact]
        public void WhenServiceUsesResponseObjectToCommunicateError()
        {
            var service = new Service();

            var timer = new Stopwatch();

            timer.Start();

            var response = service.SomeServiceCall(() =>
            {
                return new Response() { ThereWasAnError = true };
            }, 10);

            timer.Stop();

            Console.WriteLine($"execution time with response object: {timer.Elapsed}");

            Assert.True(response.ThereWasAnError);
        }

        [Fact]
        public void WhenServiceUsesNullToCommunicateError()
        {
            var service = new Service();

            var timer = new Stopwatch();

            timer.Start();

            var response = service.SomeServiceCall(() =>
            {
                return null;
            }, 10);

            timer.Stop();

            Console.WriteLine($"execution time with null response: {timer.Elapsed}");

            Assert.Equal(null, response);
        }

        [Fact]
        public void WhenServiceUsesExceptionToCommunicateError()
        {
            var service = new Service();

            var timer = new Stopwatch();

            timer.Start();

            Exception expectedException = null;

            try
            {
                var response = service.SomeServiceCall(() =>
                {
                    throw new Exception("something went wrong");

                }, 10);
            }
            catch (Exception e)
            {
                expectedException = e;
            }

            timer.Stop();

            Console.WriteLine($"execution time with response object: {timer.Elapsed}");

            Assert.Equal("something went wrong", expectedException.Message);
        }
    }
}