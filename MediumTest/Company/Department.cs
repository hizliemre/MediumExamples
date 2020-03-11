using System;
using System.Collections.Generic;
using System.Linq;

namespace MediumTest
{
    internal abstract class Department : IDepartment
    {
        private readonly List<IEmployee> _employees;

        public Department(string name)
        {
            _employees = new List<IEmployee>();
            Name = name;
        }

        public IEmployee Manager { get; private set; }
        public string Name { get; private set; }
        public int EmployeeCount => _employees.Count;
        public double AverageSalary => _employees.Average(x => x.Salary);
        public double MaximumSalary => _employees.Max(x => x.Salary);
        public double MinimumSalary => _employees.Min(x => x.Salary);

        public IEnumerable<IEmployee> Employees => _employees;

        public bool AddEmployee(IEmployee employee)
        {
            if (IsInGrade(employee, EmployeeGrade.A) && employee.Salary > AverageSalary)
                throw new InvalidOperationException("Grade A new employees salary cannot be greater than department average salary.");

            else if (IsInGrade(employee, EmployeeGrade.B) && employee.Salary < MinimumSalary)
                throw new InvalidOperationException("Grade B new employees salary cannot be less than department minimum salary.");

            else if (IsInGrade(employee, EmployeeGrade.C) && employee.Salary < AverageSalary)
                throw new InvalidOperationException("Grade C new employees salary cannot be less than department average salary.");

            else if (IsInGrade(employee, EmployeeGrade.D) && employee.Salary < MaximumSalary)
                throw new InvalidOperationException("Grade D new employees salary cannot be less than department maximum salary.");

            _employees.Add(employee);
            return true;
        }

        public bool RemoveEmployee(IEmployee employee)
        {
            _employees.Remove(employee);
            return true;
        }

        public virtual bool SetManager(IEmployee employee)
        {
            Manager = employee;
            return true;
        }

        private bool IsInGrade(IEmployee employee, params EmployeeGrade[] grades)
        {
            return grades.Contains(employee.Grade);
        }
    }
}
