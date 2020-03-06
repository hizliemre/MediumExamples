using Xunit;

namespace MediumTest.Tests
{
    public class CalculatorShould
    {
        [Fact]
        public void Be_able_to_add_two_numbers()
        {
            // Arrange
            int number1 = 10;
            int number2 = 20;
            Calculator sut = new Calculator();

            // Act
            int result = sut.Sum(number1, number2);

            // Assert
            Assert.Equal(number1 + number2, result);
        }
    }
}
