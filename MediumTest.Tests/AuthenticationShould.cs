using System;
using System.Collections.Generic;
using System.Linq;
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
            bool result = sut.Login(username, password);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(LoginDataFromField))]
        public void Be_able_login_inlinedata_right_way1(string username, string password)
        {
            // Arrange
            Authentication sut = new Authentication();

            // Act
            bool result = sut.Login(username, password);

            // Assert
            Assert.True(result);
        }

        public static IEnumerable<object[]> LoginDataFromField => new List<object[]>
        {
            new object[] {"user1", "password1" },
            new object[] {"user2", "password2" },
            new object[] {"user3", "password3" },
            new object[] {"user4", "password4" },
            new object[] {"user5", "password5" },
            new object[] {"user6", "password6" },
            new object[] {"user7", "password7" },
            new object[] {"user8", "password8" },
            new object[] {"user9", "password9" },
            new object[] {"user10", "password10" }
        };

        [Theory]
        [MemberData(nameof(LoginDataFromMethod), 5)]
        public void Be_able_login_inlinedata_right_way2(string username, string password)
        {

            // Arrange
            Authentication sut = new Authentication();

            // Act
            bool result = sut.Login(username, password);

            // Assert
            Assert.True(result);
        }

        public static IEnumerable<object[]> LoginDataFromMethod(int take)
        {
            var items = new List<object[]>
            {
                new object[] {"user1", "password1" },
                new object[] {"user2", "password2" },
                new object[] {"user3", "password3" },
                new object[] {"user4", "password4" },
                new object[] {"user5", "password5" },
                new object[] {"user6", "password6" },
                new object[] {"user7", "password7" },
                new object[] {"user8", "password8" },
                new object[] {"user9", "password9" },
                new object[] {"user10", "password10" }
            };

            return items.Take(take);
        }

        [Theory]
        [MemberData(nameof(LoginDataFromField), MemberType = typeof(MemberDataFromAnotherClass))]
        public void Be_able_login_inlinedata_right_way3(string username, string password)
        {
            // Arrange
            Authentication sut = new Authentication();

            // Act
            bool result = sut.Login(username, password);

            // Assert
            Assert.True(result);
        }
    }

    public class MemberDataFromAnotherClass
    {
        public static IEnumerable<object[]> LoginDataFromField => new List<object[]>
        {
            new object[] {"user1", "password1" },
            new object[] {"user2", "password2" },
            new object[] {"user3", "password3" },
            new object[] {"user4", "password4" },
            new object[] {"user5", "password5" },
            new object[] {"user6", "password6" },
            new object[] {"user7", "password7" },
            new object[] {"user8", "password8" },
            new object[] {"user9", "password9" },
            new object[] {"user10", "password10" }
        };
    }
}
