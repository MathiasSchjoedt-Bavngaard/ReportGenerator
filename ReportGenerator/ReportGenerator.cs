using System;
using System.Collections.Generic;

namespace ReportGenerator
{
    public enum ReportOutputFormatType
    {
        NameFirst,
        SalaryFirst
    }

    public class ReportGenerator
    {
        private readonly EmployeeDB _employeeDb;
        private ReportOutputFormatType _currentOutputFormat;
        private List<IPrintEmployees> _PrintFormatTypes = new List<IPrintEmployees>();
        private EmployExtractor _extrac;
       
        public ReportGenerator(EmployeeDB employeeDb)
        {
            if (employeeDb == null) throw new ArgumentNullException("employeeDb");

            _currentOutputFormat = ReportOutputFormatType.NameFirst;
            _employeeDb = employeeDb;

            IPrintEmployees NewPrinter = new PrintListNameFirst();
            _PrintFormatTypes.Add(NewPrinter);
            _PrintFormatTypes.Add(new PrintListSalaryFirst());

            _extrac = new EmployExtractor();
        }

        public void CompileReport(string Format)
        {
           _extrac.updateListFrom(_employeeDb);

            if (_extrac.EmployeesNow != null)
            {

                if (_PrintFormatTypes.Find(x => x.getFormat() == Format) == null)
                   Console.WriteLine("First not Found");
                _PrintFormatTypes.Find(x => x.getFormat() == Format).Print(_extrac.EmployeesNow);
            }
            else
            throw new ArgumentNullException("_extractfail");
        }


        public void SetOutputFormat(ReportOutputFormatType format)
        {
            _currentOutputFormat = format;
        }


    }
}