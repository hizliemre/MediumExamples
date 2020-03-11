namespace MediumTest
{
    public interface IDepartment
    {
        public string Name { get; }
        IEmployee Manager { get; }
        public int EmployeeCount { get; }
        public double AverageSalary { get; }
        bool AddEmployee(IEmployee employee);
        bool SetManager(IEmployee employee);
    }
}
