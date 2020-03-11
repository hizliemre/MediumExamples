using System;

namespace MediumTest.ExampleCompany
{
    internal class InformationTechnologyDepartment : Department
    {
        private readonly int _managerMinimumExperience;

        public InformationTechnologyDepartment()
            : base("IT Department", DepartmentType.IT)
            => _managerMinimumExperience = 8;

        public override bool SetManager(IEmployee employee)
        {
            if (employee.Experience < _managerMinimumExperience)
                throw new InvalidOperationException($"{Name} manager have to be minimum {_managerMinimumExperience} years experience.");
            return base.SetManager(employee);
        }
    }
}
