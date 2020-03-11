using System;

namespace MediumTest
{
    internal class InformationTechnologyDepartment : Department
    {
        private readonly int _managerMinimumExperience;

        public InformationTechnologyDepartment()
            : base("IT Department")
            => _managerMinimumExperience = 8;

        public override bool SetManager(IEmployee employee)
        {
            if (employee.Experience < _managerMinimumExperience)
                throw new InvalidOperationException($"{Name} manager have to be minimum {_managerMinimumExperience} years experience.");
            return base.SetManager(employee);
        }
    }
}
