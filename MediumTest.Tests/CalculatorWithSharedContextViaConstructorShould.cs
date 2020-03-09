using FluentAssertions;
using MediumTest.Tests.CalculatorArrange;
using System;
using Xunit;

namespace MediumTest.Tests
{
    public sealed class CalculatorWithSharedContextViaConstructorShould : IDisposable
    {
        private readonly ExpensiveCalculator _sut;

        public CalculatorWithSharedContextViaConstructorShould()
        {
            _sut = new ExpensiveCalculator();
        }

        public void Dispose()
        {
            // İhtiyaç halinde nesneleri burada dispose etmemiz gerekir.
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
