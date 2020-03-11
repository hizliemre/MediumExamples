using System.Collections.Generic;

namespace MediumTest.Company
{
    public interface ICompany
    {
        public IEnumerable<IDepartment> Departments { get; }
        public IEnumerable<IEmployee> Employees { get; }
        public void LoadDepartments(params IDepartment[] departments);
        public void LoadEmployees(params IEmployee[] employees);
    }

    internal sealed class Company : ICompany
    {
        public Company()
        {
            _departments = new List<IDepartment>();
            _employees = new List<IEmployee>();
        }

        private List<IDepartment> _departments;
        private List<IEmployee> _employees;

        public IEnumerable<IDepartment> Departments => _departments;

        public IEnumerable<IEmployee> Employees => _employees;

        public void LoadDepartments(params IDepartment[] departments)
        {
            _departments.AddRange(departments);
        }

        public void LoadEmployees(params IEmployee[] employees)
        {
            _employees.AddRange(employees);
        }
    }
}
