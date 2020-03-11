using System.Collections.Generic;

namespace MediumTest
{
    public interface IDepartment
    {
        IEnumerable<IEmployee> Employees { get; }
        public string Name { get; }
        IEmployee Manager { get; }
        public int EmployeeCount { get; }
        public double AverageSalary { get; }
        bool AddEmployee(IEmployee employee);
        bool RemoveEmployee(IEmployee employee);
        bool SetManager(IEmployee employee);
    }
}
