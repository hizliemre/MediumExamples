using FluentAssertions;
using MediumTest.ExampleCompany;
using System;
using System.Linq;
using Xunit;

namespace MediumTest.Tests.CompanyTests
{
    public class CompanyShould
    {
        [Fact]
        public void Hire_employee()
        {
            // Arrange
            var company = new Company();
            var employee = new Employee("Emre Hızlı", 2000, new DateTime(2010, 7, 1));

            // Act
            var itDepartment = company.Departments.FirstOrDefault(x => x.DepartmentType == DepartmentType.IT);
            itDepartment.HireEmployee(employee);

            // Assert
            company.Employees.Should().NotBeEmpty();
            itDepartment.EmployeeCount.Should().Be(1);
        }
    }
}
