using FluentAssertions;
using MediumTest.Tests.CalculatorArrange;
using Xunit;

namespace MediumTest.Tests
{
    public sealed class CalculatorWithSharedContextViaClassFixtureShould : IClassFixture<ExpensiveCalculator>
    {
        private readonly ExpensiveCalculator _sut;

        public CalculatorWithSharedContextViaClassFixtureShould(ExpensiveCalculator sut)
        {
            _sut = sut;
        }

        [Theory]
        [ClassData(typeof(CalculatorAddStronglyTypedData))]
        public void Be_able_to_add_two_numbers(int number1, int number2)
        {
            // Act
            var result = _sut.Sum(number1, number2);

            // Assert
            result.Should().Be(number1 + number2);
        }

        [Theory]
        [ClassData(typeof(CalculatorAddStronglyTypedData))]
        public void Be_able_to_multiply_two_numbers(int number1, int number2)
        {
            // Act
            var result = _sut.Multiply(number1, number2);

            // Assert
            result.Should().Be(number1 * number2);
        }
    }
}