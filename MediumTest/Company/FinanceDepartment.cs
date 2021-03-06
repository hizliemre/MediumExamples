﻿using System;

namespace MediumTest.ExampleCompany
{
    internal class FinanceDepartment : Department
    {
        private readonly int _managerMinimumExperience;

        public FinanceDepartment()
            : base("Finance Department", DepartmentType.Finance)
            => _managerMinimumExperience = 15;

        public override bool SetManager(IEmployee employee)
        {
            if (employee.Experience < _managerMinimumExperience)
                throw new InvalidOperationException($"{Name} manager have to be minimum {_managerMinimumExperience} years experience.");
            return base.SetManager(employee);
        }
    }
}
