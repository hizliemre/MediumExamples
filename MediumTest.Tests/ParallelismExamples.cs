using System.Threading;
using Xunit;

namespace MediumTest.Tests
{
    [Collection("my collection")]
    public class ParallelismExamples1
    {
        [Fact]
        public void Test1()
        {
            Thread.Sleep(5000);
        }
    }

    [Collection("my collection")]
    public class ParallelismExamples2
    {
        [Fact]
        public void Test2()
        {
            Thread.Sleep(5000);
        }
    }
}
