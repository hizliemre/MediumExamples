using System.Threading.Tasks;
using Xunit;

namespace MediumTest.Tests
{
    public class ParallelismExamplesAsync
    {
        [Fact]
        public async Task Test1()
        {
            await Task.Delay(5000);
        }

        [Fact]
        public async Task Test2()
        {
            await Task.Delay(5000);
        }
    }
}
