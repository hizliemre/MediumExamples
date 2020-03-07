using System;
using Xunit;

namespace MediumTest.Tests
{
    public class AuthenticationShould
    {
        [Theory]
        [InlineData("emre")]
        [InlineData("emrehizli")]
        public void Be_able_login(string username)
        {
            // Arrange
            Authentication sut = new Authentication();

            // Act
            bool result = sut.Login(username);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("emr")]
        [InlineData("em")]
        public void Cannot_login(string username)
        {
            // Arrange
            Authentication sut = new Authentication();

            // Act
            void act() => sut.Login(username);

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }
    }
}
