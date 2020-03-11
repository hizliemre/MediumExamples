using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MediumTest.Tests")]
namespace MediumTest.ExampleCompany
{
    internal sealed class Company : ICompany
    {
        public Company()
        {
            _departments = new List<IDepartment>();
            Initialize();
        }

        private readonly List<IDepartment> _departments;

        public IEnumerable<IDepartment> Departments => _departments;

        public IEnumerable<IEmployee> Employees => _departments.SelectMany(x => x.Employees);

        private void Initialize()
        {
            _departments.Add(new HumanResourcesDepartment());
            _departments.Add(new InformationTechnologyDepartment());
            _departments.Add(new FinanceDepartment());
        }
    }
}
