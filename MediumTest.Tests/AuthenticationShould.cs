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
        [InlineData("user1", "password1")]
        [InlineData("user2", "password2")]
        [InlineData("user3", "password3")]
        [InlineData("user4", "password4")]
        [InlineData("user5", "password5"), InlineData("user6", "password6"), InlineData("user7", "password7"),
         InlineData("user8", "password8"), InlineData("user9", "password9"), InlineData("user10", "password10")]
        public void Be_able_login_inlinedata_wrong_way(string username, string password)
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
