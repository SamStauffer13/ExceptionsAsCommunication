using Xunit;
using Xunit.Abstractions;
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

        public class WhenCallstackIsShallow
        {
	        private int callstack = 5;

			private readonly ITestOutputHelper output;
            public WhenCallstackIsShallow(ITestOutputHelper output)
            {
                this.output = output;
            }

            [Fact]
            public void ResponseObjectToCommunicateError()
            {
                var service = new Service();

                var timer = new Stopwatch();

                timer.Start();

                var response = service.SomeServiceCall(() => new Response { ThereWasAnError = true }, callstack);

                timer.Stop();

                output.WriteLine($"execution time with response object: {timer.Elapsed}");

                Assert.True(response.ThereWasAnError);
            }

            [Fact]
            public void NullToCommunicateError()
            {
                var service = new Service();

                var timer = new Stopwatch();

                timer.Start();

                var response = service.SomeServiceCall(() => null, callstack);

                timer.Stop();

                output.WriteLine($"execution time with null response: {timer.Elapsed}");

                Assert.Equal(null, response);
            }

            [Fact]
            public void ExceptionToCommunicateError()
            {
                var service = new Service();

                var timer = new Stopwatch();

                Exception expectedException = null;

                timer.Start();

                try
                {
                    var response = service.SomeServiceCall(() => throw new Exception("something went wrong"), callstack);
                }
                catch (Exception e)
                {
                    expectedException = e;
                }

                timer.Stop();

                output.WriteLine($"execution time with response object: {timer.Elapsed}");

                Assert.Equal("something went wrong", expectedException.Message);
            }
        }

        public class WhenCallstackIsTenFathomsDeep
        {
	        private int callstack = 10000;

			private readonly ITestOutputHelper output;
            public WhenCallstackIsTenFathomsDeep(ITestOutputHelper output)
            {
                this.output = output;
            }

            [Fact]
            public void ResponseObjectToCommunicateError()
            {
                var service = new Service();

                var timer = new Stopwatch();

                timer.Start();

                var response = service.SomeServiceCall(() => new Response { ThereWasAnError = true }, callstack);

                timer.Stop();

                output.WriteLine($"execution time with response object: {timer.Elapsed}");

                Assert.True(response.ThereWasAnError);
            }

            [Fact]
            public void NullToCommunicateError()
            {
                var service = new Service();

                var timer = new Stopwatch();

                timer.Start();

                var response = service.SomeServiceCall(() => null, callstack);

                timer.Stop();

                output.WriteLine($"execution time with null response: {timer.Elapsed}");

                Assert.Equal(null, response);
            }

            [Fact]
            public void ExceptionToCommunicateError()
            {
                var service = new Service();

                var timer = new Stopwatch();

                Exception expectedException = null;

                timer.Start();

                try
                {
                    var response = service.SomeServiceCall(() => throw new Exception("something went wrong"), callstack);
                }
                catch (Exception e)
                {
                    expectedException = e;
                }

                timer.Stop();

                output.WriteLine($"execution time with response object: {timer.Elapsed}");

                Assert.Equal("something went wrong", expectedException.Message);
            }
        }
    }
}