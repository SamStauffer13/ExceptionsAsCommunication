using Xunit;
using Logic;

namespace Logic.Tests
{
    public class ServiceTests
    {
        [Fact]
        public void FirstTest()
        {
            var service = new Service();

            var response = service.DoWork();
            
            Assert.True(response.IsSuccess);
        }
    }
}