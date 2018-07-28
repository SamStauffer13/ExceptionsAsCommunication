using Xunit;
using Xunit.Abstractions;
using Logic;
using System;
using System.Diagnostics;

namespace Logic.Tests
{
    public class ServiceTests  // cd to this dir then run dotnet test in terminal
    {
        private readonly ITestOutputHelper output;
        public ServiceTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void MethodIsRecursiveSoWeCanControlCallStackSize()
        {
            var service = new Service();

            var expectedNumberOfExecutions = 10;

            var response = service.SomeServiceCall(GetCodeToExecute(ResponseType.Object), expectedNumberOfExecutions);

            Assert.Equal(expectedNumberOfExecutions, service.NumberOfExecutions);
        }

        [Fact]
        public void ReturningObjectToCommunicateError()
        {
            var service = new Service();

            var response = service.SomeServiceCall(GetCodeToExecute(ResponseType.Object), 0);

            Assert.True(response.ThereWasAnError);
        }

        [Fact]
        public void ReturningNullToCommunicateError()
        {
            var service = new Service();

            var response = service.SomeServiceCall(GetCodeToExecute(ResponseType.Null), 0);

            Assert.Equal(null, response);
        }

        [Fact]
        public void ThrowingExceptionToCommunicateError()
        {
            var service = new Service();

            var expectedMessage = "something went wrong";

            try
            {
                var response = service.SomeServiceCall(() => throw new Exception(expectedMessage), 0);
            }
            catch (Exception e)
            {
                Assert.Equal(expectedMessage, e.Message);
            }
        }

        [Theory]
        [InlineData(ResponseType.Object, 1)]
        [InlineData(ResponseType.Object, 100)]
        [InlineData(ResponseType.Object, 5000)]
        [InlineData(ResponseType.Null, 1)]
        [InlineData(ResponseType.Null, 100)]
        [InlineData(ResponseType.Null, 5000)]
        [InlineData(ResponseType.Exception, 1)]
        [InlineData(ResponseType.Exception, 100)]
        [InlineData(ResponseType.Exception, 5000)]
        public void ProofThatCatchingExceptionsIsSlow(ResponseType responseType, int callstackSize)
        {
            var service = new Service();

            var timer = new Stopwatch();

            var codeToExecute = GetCodeToExecute(responseType);

            timer.Start();

            try
            {
                var response = service.SomeServiceCall(codeToExecute, callstackSize);
            }
            catch (Exception)
            {

            }

            timer.Stop();

            output.WriteLine($"handling an {responseType.ToString()} response with  a {callstackSize} deep callstack took {timer.Elapsed.Milliseconds}ms");

            Assert.True(timer.Elapsed.Milliseconds < 2);
        }

        public enum ResponseType
        {
            Null,
            Object,
            Exception
        }
        public Func<Response> GetCodeToExecute(ResponseType response) // cuz idk the syntax to use a delegate as an InlineData parameter
        {
            switch (response)
            {
                case ResponseType.Null: return () => null;
                case ResponseType.Exception: return () => throw new Exception("something went wrong");
                default:
                case ResponseType.Object: return () => new Response { ThereWasAnError = true };
            }
        }
    }
}