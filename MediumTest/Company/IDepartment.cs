using System.Collections.Generic;

namespace MediumTest.ExampleCompany
{
    public enum DepartmentType
    {
        HR,
        IT,
        Finance
    }

    public interface IDepartment
    {
        IEnumerable<IEmployee> Employees { get; }
        public string Name { get; }
        public DepartmentType DepartmentType { get; }
        IEmployee Manager { get; }
        public int EmployeeCount { get; }
        public double AverageSalary { get; }
        public double MaximumSalary { get; }
        public double MinimumSalary { get; }
        bool AddEmployee(IEmployee employee);
        bool RemoveEmployee(IEmployee employee);
        bool SetManager(IEmployee employee);
    }
}
