using FluentAssertions;
using MediumTest.ExampleCompany;
using Moq;
using Xunit;

namespace MediumTest.Tests.CompanyTestsWithMoq
{
    public class CompanyWithMoqShould
    {
        [Fact]
        public void Hire_employee()
        {
            // Arrange
            var department = new Mock<IDepartment>();
            var company = new Mock<ICompany>();
            company.Setup(x => x.ITDepartment).Returns(department.Object);
            var employee = new Mock<IEmployee>();

            // Act
            company.Object.ITDepartment.HireEmployee(employee.Object);

            // Assert
            department.Verify(x => x.AddEmployee(It.IsAny<IEmployee>()));
        }

        [Fact]
        public void Hire_employee_concrete_department()
        {
            // Arrange
            var department = new Mock<InformationTechnologyDepartment>();
            department.Setup(x => x.AverageSalary).Returns(1000);

            var company = new Mock<ICompany>();
            company.Setup(x => x.ITDepartment).Returns(department.Object);

            var employee = new Mock<IEmployee>();
            employee.Setup(x => x.Grade).Returns(EmployeeGrade.A);
            employee.Setup(x => x.Salary).Returns(1000);

            // Act
            company.Object.ITDepartment.HireEmployee(employee.Object);

            // Assert
            department.Object.EmployeeCount.Should().Be(1);
        }
    }
}
