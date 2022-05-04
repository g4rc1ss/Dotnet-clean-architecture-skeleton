using FluentAssertions;
using Xunit;

namespace TestIntegracion
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            1.Should().As<int>();
        }
    }
}
