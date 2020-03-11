using System;

namespace MediumTest.ExampleCompany
{
    internal class HumanResourcesDepartment : Department
    {
        private readonly int _managerMinimumExperience;

        public HumanResourcesDepartment()
            : base("HR Department")
            => _managerMinimumExperience = 5;

        public override bool SetManager(IEmployee employee)
        {
            if (employee.Experience < _managerMinimumExperience)
                throw new InvalidOperationException($"{Name} manager have to be minimum {_managerMinimumExperience} years experience.");
            return base.SetManager(employee);
        }
    }
}
