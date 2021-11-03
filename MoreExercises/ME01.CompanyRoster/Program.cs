using System;
using System.Collections.Generic;
using System.Linq;

namespace ME01.CompanyRoster
{
    class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }

        public static string CalculateAverageSalary(List<Employee> employees)
        {
            decimal highestSalary = 0.0m;
            string highestDepartment = string.Empty;
            foreach (Employee department in employees)
            {
                IEnumerable<Employee> currDepartment = employees.Where(name => name.Department == department.Department);

                decimal currSalary = 0.0m;
                int currCount = 0;
                foreach (Employee salary in currDepartment)
                {
                    currSalary += salary.Salary;
                    currCount++;
                }
                currSalary /= currCount;

                if (currSalary >= highestSalary)
                {
                    highestSalary = currSalary;
                    highestDepartment = department.Department;
                }
            }

            return highestDepartment; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int employeeQty = int.Parse(Console.ReadLine());

            List<Employee> employeeList = new List<Employee>();
            for (int i = 0; i < employeeQty; i++)
            {
                string[] cmd = Console.ReadLine().Split();

                string name = cmd[0];
                decimal salary = decimal.Parse(cmd[1]);
                string department = cmd[2];

                employeeList.Add(new Employee()
                {
                    Name = name,
                    Salary = salary,
                    Department = department
                });
            }

            string highestDepartment = Employee.CalculateAverageSalary(employeeList);

            IEnumerable<Employee> highestDepartmentList = employeeList
                .Where(name => name.Department == highestDepartment);

            Console.WriteLine($"Highest Average Salary: {highestDepartment}");
            foreach (Employee employee in highestDepartmentList.OrderByDescending(emp => emp.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }
    }
}
