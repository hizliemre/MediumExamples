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

        [Fact]
        public void Cannot_add_two_numbers()
        {
            // Arrange
            int number1 = 10;
            int number2 = 20;
            Calculator sut = new Calculator();

            // Act
            int result = sut.Sum(number1, number2);

            // Assert
            Assert.Equal(number1 + 5, result);
        }

        [Fact]
        public void Be_able_to_add_two_numbers_multiple_cases_wrong_way()
        {
            // Arrange 
            Calculator sut = new Calculator();

            int number1 = 10;
            int number2 = 20;

            int number3 = 15;
            int number4 = 25;

            // Act
            int result1 = sut.Sum(number1, number2);
            int result2 = sut.Sum(number3, number4);

            // Assert
            Assert.Equal(number1 + number2, result1);
            Assert.Equal(number3 + number4, result2);
        }

        [Theory]
        [InlineData(10, 20)]
        [InlineData(15, 25)]
        public void Be_able_to_add_two_numbers_multiple_cases_right_way(int number1, int number2)
        {
            // Arrange 
            Calculator sut = new Calculator();

            // Act
            int result = sut.Sum(number1, number2);

            // Assert
            Assert.Equal(number1 + number2, result);
        }

    }
}
