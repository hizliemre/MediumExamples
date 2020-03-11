namespace MediumTest
{
    public interface IDepartmentManagerProvider
    {
        IDepartmentManager GetManager(IDepartment department);
    }

    internal class DepartmentManagerProvider : IDepartmentManagerProvider
    {
        public IDepartmentManager GetManager(IDepartment department)
        {
            return new DepartmentManager(department);
        }
    }

    internal sealed class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartment _department;

        public DepartmentManager(IDepartment department)
        {
            _department = department;
        }

        public void Fire(IEmployee employee)
        {
            employee.Fire();
            _department.RemoveEmployee(employee);
        }

        public void Hire(IEmployee employee)
        {
            employee.Hire();
            _department.AddEmployee(employee);
        }
    }

    public static class Helpers
    {
        private static readonly IDepartmentManagerProvider _dmProvider = new DepartmentManagerProvider();

        public static void FireEmployee(this IDepartment department, IEmployee employee)
        {
            var dm = _dmProvider.GetManager(department);
            dm.Fire(employee);
        }

        public static void HireEmployee(this IDepartment department, IEmployee employee)
        {
            var dm = _dmProvider.GetManager(department);
            dm.Hire(employee);
        }
    }
}
