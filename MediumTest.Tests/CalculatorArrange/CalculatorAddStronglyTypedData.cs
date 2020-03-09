using Xunit;

namespace MediumTest.Tests.CalculatorArrange
{
    public class CalculatorAddStronglyTypedData : TheoryData<int, int>
    {
        public CalculatorAddStronglyTypedData()
        {
            Add(10, 20);
            Add(20, 30);
            Add(25, 35);
            Add(45, 55);
        }
    }

    [CollectionDefinition("Expensive Calculator Fixture")]
    public class ExpensiveCalculatorCollectionFixture : ICollectionFixture<ExpensiveCalculator>
    { }
}
