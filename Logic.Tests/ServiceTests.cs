using Xunit;
using Logic;

namespace Logic.Tests
{
    public class ServiceTests
    {
        // cd to this dir then run dotnet test in terminal
        [Fact]
        public void FirstTest()
        {
            var service = new Service();

            var response = service.SomeServiceCall(()=> {return new Response();});
            
            Assert.True(response.IsSuccess);
        }
    }
}