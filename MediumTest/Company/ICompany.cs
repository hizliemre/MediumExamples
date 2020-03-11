using System.Collections.Generic;

namespace MediumTest.Company
{
    public interface ICompany
    {
        public IEnumerable<IDepartment> Departments { get; }
        public IEnumerable<IEmployee> Employees { get; }
    }
}
