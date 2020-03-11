using MediumTest.ExampleCompany;
using System;

namespace MediumTest.Tests.CompanyTests
{
    public class CompanyFixture
    {
        public ICompany Company { get; }

        public CompanyFixture()
        {
            Company = new Company();
            Initalize();
        }

        private void Initalize()
        {
            // Test senaryolarımız için çalışan default elemanlarımız.

            Company.ITDepartment.HireEmployee(new Employee("Barış Küçük", 2000, new DateTime(2010, 1, 1)));
            Company.ITDepartment.HireEmployee(new Employee("Erdem Doğrul", 4000, new DateTime(2011, 1, 1)));
            Company.ITDepartment.HireEmployee(new Employee("Halil Efe", 5000, new DateTime(2012, 1, 1)));
            Company.ITDepartment.HireEmployee(new Employee("Alper Arık", 8000, new DateTime(2013, 1, 1)));

            Company.HRDepartment.HireEmployee(new Employee("Gamze Çalışır", 3500, new DateTime(2014, 1, 1)));
            Company.HRDepartment.HireEmployee(new Employee("Selin Yağcı", 4000, new DateTime(2012, 1, 1)));
            Company.HRDepartment.HireEmployee(new Employee("Tuğba Hızlı", 6000, new DateTime(2010, 1, 1)));

            Company.FinanceDepartment.HireEmployee(new Employee("Ali Babacan", 6000, new DateTime(2014, 1, 1)));
            Company.FinanceDepartment.HireEmployee(new Employee("Mehmet Şimşek", 10000, new DateTime(2014, 1, 1)));
        }
    }
}
