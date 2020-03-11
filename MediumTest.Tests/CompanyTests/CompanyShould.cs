using MediumTest.ExampleCompany;
using System;

namespace MediumTest.Tests.CompanyTests
{
    public class CompanyShould
    {
        public void Test()
        {
            // Arrange
            var company = new Company();
            var employee = new Employee("Emre Hızlı", 2000, new DateTime(2010, 7, 1));

            // Act

            // Assert
        }
    }
}
