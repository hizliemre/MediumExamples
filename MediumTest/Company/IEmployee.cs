﻿using System;

namespace MediumTest.ExampleCompany
{
    public enum EmployeeGrade
    {
        A,
        B,
        C,
        D
    }

    public enum WorkingStatus
    {
        Working,
        Fired,
    }

    public interface IEmployee
    {
        public string Name { get; }
        public double Salary { get; }
        public int Experience { get; }
        public DateTime HireDate { get; }
        public DateTime FireDate { get; }
        public IDepartment Department { get; }
        public EmployeeGrade Grade { get; }
        public WorkingStatus WorkingStatus { get; }
        public void Fire();
        public void Hire();
    }
}
