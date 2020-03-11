namespace MediumTest
{
    public interface IDepartment
    {
        public string Name { get; }
        IEmployee Manager { get; }
        public int EmployeeCount { get; }
        public double AverageSalary { get; }
        void AddEmployee(IEmployee employee);
        void SetManager(IEmployee employee);
    }
}
