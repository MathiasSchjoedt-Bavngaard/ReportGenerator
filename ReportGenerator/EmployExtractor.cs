using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator
{
    public class EmployExtractor
    {
        public System.Collections.Generic.List<Employee> EmployeesNow
        {
            get;
            private set;
        }

        public EmployExtractor()
        {
            EmployeesNow = new List<Employee>();
        }

        


        public void updateListFrom(EmployeeDB employeeDB)
        {
            EmployeesNow = ExstractEmploylist(employeeDB);
        }

        private List<Employee> ExstractEmploylist(EmployeeDB employeeDB)
        {
            var employees = new List<Employee>();
            Employee employee;

            employeeDB.Reset();

            // Get all employees
            while ((employee = employeeDB.GetNextEmployee()) != null)
            {
                employees.Add(employee);
            }
            return employees;
        }
    }
}