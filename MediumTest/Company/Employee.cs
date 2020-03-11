using System;

namespace MediumTest
{
    internal sealed class Employee : IEmployee
    {
        public Employee(string name, int salary, DateTime careerStartDate)
        {
            Name = name;
            Salary = salary;
            Experience = DateTime.Now.Year - careerStartDate.Year;

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
        public DateTime RecruitmentDate { get; private set; }
        public DateTime FireDate { get; private set; }
        public EmployeeGrade Grade { get; private set; }
        public WorkingStatus WorkingStatus => FireDate != null ? WorkingStatus.Fired : WorkingStatus.Working;

        public void Fire()
        {
            if (WorkingStatus == WorkingStatus.Fired)
                throw new InvalidOperationException("This employee is already fired.");
            FireDate = DateTime.Now;
        }

        public void Recruitment()
        {
            if (WorkingStatus == WorkingStatus.Working)
                throw new InvalidOperationException("This employee is already working.");
            RecruitmentDate = DateTime.Now;
        }
    }
}
