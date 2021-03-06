﻿using System;

namespace MediumTest.ExampleCompany
{
    internal sealed class Employee : IEmployee
    {
        public Employee(string name, double salary, DateTime careerStartDate)
        {
            Name = name;
            Salary = salary;
            Experience = DateTime.Now.Year - careerStartDate.Year;

            if (Experience < 0)
                throw new InvalidOperationException("Employee experience should not less than zero.");
        }

        public string Name { get; private set; }
        public double Salary { get; private set; }
        public IDepartment Department { get; private set; }
        public int Experience { get; private set; }
        public DateTime HireDate { get; private set; }
        public DateTime FireDate { get; private set; }
        public EmployeeGrade Grade
        {
            get
            {
                if (Experience <= 2) return EmployeeGrade.A;
                else if (Experience > 2 && Experience <= 6) return EmployeeGrade.B;
                else if (Experience > 6 && Experience <= 10) return EmployeeGrade.C;
                else return EmployeeGrade.D;
            }
        }
        public WorkingStatus WorkingStatus => FireDate != null ? WorkingStatus.Fired : WorkingStatus.Working;

        public void Fire()
        {
            if (WorkingStatus == WorkingStatus.Fired)
                throw new InvalidOperationException("This employee is already fired.");
            FireDate = DateTime.Now;
        }

        public void Hire()
        {
            if (WorkingStatus == WorkingStatus.Working)
                throw new InvalidOperationException("This employee is already working.");
            HireDate = DateTime.Now;
        }
    }
}
