using System;

namespace MediumTest
{
    public enum EmployeeGrade
    {
        A,
        B,
        C,
        D
    }

    public interface IEmployee
    {
        public string Name { get; }
        public int Salary { get; }
        public int Experience { get; }
        public DateTime StartDate { get; }
        public IDepartment Department { get; }
        public EmployeeGrade Grade { get; }
    }
}
