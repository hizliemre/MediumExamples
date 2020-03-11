using FluentAssertions;
using MediumTest.ExampleCompany;
using System;
using System.Linq;
using Xunit;

namespace MediumTest.Tests.CompanyTests
{
    public class CompanyShould : IClassFixture<CompanyFixture>
    {
        private readonly CompanyFixture _companyFixture;

        public CompanyShould(CompanyFixture companyFixture)
        {
            _companyFixture = companyFixture;
        }

        [Fact]
        public void Hire_employee()
        {
            // Arrange
            var company = new Company();
            var employee = new Employee("Emre Hızlı", 2000, new DateTime(2010, 7, 1));

            // Act
            company.ITDepartment.HireEmployee(employee);

            // Assert
            company.Employees.Should().HaveCount(1);
            company.ITDepartment.EmployeeCount.Should().Be(1);
        }

        [Fact]
        public void Cannot_hire_employee()
        {
            // Arrange
            var company = new Company();

            company.ITDepartment.HireEmployee(new Employee("Barış Küçük", 3000, new DateTime(2015, 1, 1)));
            company.ITDepartment.HireEmployee(new Employee("Erdem Doğrul", 3000, new DateTime(2015, 1, 1)));
            company.ITDepartment.HireEmployee(new Employee("Halil Efe", 3000, new DateTime(2015, 1, 1)));

            // Act
            var newEmployee = new Employee("Emre Hızlı", 5000, new DateTime(2019, 1, 1));
            Action act = () => company.ITDepartment.HireEmployee(newEmployee);

            // Assert
            act.Should().ThrowExactly<InvalidOperationException>();
        }

        [Fact]
        public void Cannot_hire_employee_in_case1()
        {
            // Arrange
            var salary = _companyFixture.Company.ITDepartment.AverageSalary + 50;
            var newEmployee = new Employee("Emre Hızlı", salary, new DateTime(2019, 1, 1));

            // Act
            Action act = () => _companyFixture.Company.ITDepartment.HireEmployee(newEmployee);

            // Assert
            act.Should().ThrowExactly<InvalidOperationException>();
        }

        [Fact]
        public void Hire_employee_in_case1()
        {
            // Arrange
            var salary = _companyFixture.Company.ITDepartment.AverageSalary - 50;
            var newEmployee = new Employee("Emre Hızlı", salary, new DateTime(2019, 1, 1));

            // Act
            Action act = () => _companyFixture.Company.ITDepartment.HireEmployee(newEmployee);

            // Assert
            act.Should().NotThrow();
            _companyFixture.Company.ITDepartment.Employees.Should().Contain(newEmployee);
        }
    }
}
