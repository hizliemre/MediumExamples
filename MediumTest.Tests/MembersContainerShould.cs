using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

[assembly: TestCaseOrderer("MediumTest.Tests.DisplayNameOrderer", "MediumTest.Tests")]
namespace MediumTest.Tests
{
    public class MembersContainerShould : IClassFixture<MembersContainer>
    {
        private readonly MembersContainer _sut;

        public MembersContainerShould(MembersContainer sut)
        {
            _sut = sut;
        }

        [Fact]
        public void A_Not_be_empty()
        {
            // Act
            _sut.Add(1);

            // Assert
            _sut.Items.Should().NotBeEmpty();
        }

        [Fact]
        public void Z_Be_empty()
        {
            // Assert
            _sut.Items.Should().BeEmpty();
        }

    }

    public class DisplayNameOrderer : ITestCaseOrderer
    {
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
        {
            return testCases.OrderBy(x => x.DisplayName);
        }
    }
}
