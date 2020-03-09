using Xunit;

namespace MediumTest.Tests
{
    [Collection("Expensive Calculator Fixture")]
    public class CollectionFixture1Should
    {
        private readonly ExpensiveCalculator _sut;

        public CollectionFixture1Should(ExpensiveCalculator sut)
            => _sut = sut;

        // Some tests....
    }

    [Collection("Expensive Calculator Fixture")]
    public class CollectionFixture2Should
    {
        private readonly ExpensiveCalculator _sut;

        public CollectionFixture2Should(ExpensiveCalculator sut)
            => _sut = sut;

        // Some tests....
    }
}
