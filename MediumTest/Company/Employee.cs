using System;

namespace MediumTest
{
    internal class Employee : IEmployee
    {
        public Employee(string name, int salary, DateTime careerStartDate, DateTime startDate)
        {
            Name = name;
            Salary = salary;
            Experience = DateTime.Now.Year - careerStartDate.Year;
            StartDate = startDate;

            if (Experience < 0)
                throw new InvalidOperationException("Employee experience should not less than zero.");

            if (Experience <= 2) Grade = EmployeeGrade.A;
            else if (Experience > 2 && Experience <= 6) Grade = EmployeeGrade.B;
            else if (Experience > 6 && Experience <= 10) Grade = EmployeeGrade.C;
            else Grade = EmployeeGrade.D;
        }

        public string Name { get; private set; }
        public int Salary { get; private set; }
        public IDepartment Department { get; private set; }
        public int Experience { get; private set; }
        public DateTime StartDate { get; private set; }
        public EmployeeGrade Grade { get; private set; }
    }
}
