using System.Collections.Generic;

namespace MediumTest.ExampleCompany
{
    public interface ICompany
    {
        public IEnumerable<IDepartment> Departments { get; }
        public IEnumerable<IEmployee> Employees { get; }
        public IDepartment ITDepartment { get; }
        public IDepartment HRDepartment { get; }
        public IDepartment FinanceDepartment { get; }
    }
}
