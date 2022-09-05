using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ReportGenerator
{
    

    public class PrintListSalaryFirst : IPrintEmployees
    {
        public string Format = "Salary";
        public string getFormat() { return Format; }
        public void Print(List<Employee> employees)
        {
            Console.WriteLine("{0}-first report", Format);
            foreach (Employee e in employees)
            {
                Console.WriteLine("_______________");
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(e))
                {
                    if (descriptor.Name == Format)
                    {
                        string name = descriptor.Name;
                        object value = descriptor.GetValue(e);
                        Console.WriteLine("{0}: {1}", name, value);
                    }
                }
                

                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(e))
                {
                    if (descriptor.Name != Format)
                    {
                        string name = descriptor.Name;
                        object value = descriptor.GetValue(e);
                        Console.WriteLine("{0}:  {1}", name, value);
                    }

                }

                Console.WriteLine("-------------");
            }
        }

       
    }
}