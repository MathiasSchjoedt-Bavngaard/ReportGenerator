using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator
{
    public interface IPrintEmployees
    {
        public void Print(List<Employee> employees);
        public string getFormat();
    }
}