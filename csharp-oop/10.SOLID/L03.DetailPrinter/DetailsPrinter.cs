using System;
using System.Collections.Generic;

namespace L03.DetailPrinter
{
    public class DetailsPrinter
    {
        private readonly IEnumerable<IEmployee> employees;

        public DetailsPrinter(IEnumerable<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
