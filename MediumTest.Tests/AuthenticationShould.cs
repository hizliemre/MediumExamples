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

        [Theory]
        [InlineData("user1")]
        [InlineData("user2")]
        [InlineData("user3")]
        [InlineData("user4")]
        [InlineData("user5"), InlineData("user6"), InlineData("user7"),
         InlineData("user8"), InlineData("user9"), InlineData("user10")]
        public void Be_able_login_inlinedata_wrong_way(string username)
        {
            // Arrange
            Authentication sut = new Authentication();

            // Act
            bool result = sut.Login(username);

            // Assert
            Assert.True(result);
        }
    }
}
