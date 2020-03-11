using System;

namespace MediumTest
{
    internal class FinanceDepartment : Department
    {
        private readonly int _managerMinimumExperience;

        public FinanceDepartment()
            : base("Finance Department")
            => _managerMinimumExperience = 15;

        public override bool SetManager(IEmployee employee)
        {
            if (employee.Experience < _managerMinimumExperience)
                throw new InvalidOperationException($"{Name} manager have to be minimum {_managerMinimumExperience} years experience.");
            return base.SetManager(employee);
        }
    }
}
