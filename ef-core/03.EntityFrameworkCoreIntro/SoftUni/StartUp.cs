using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            SoftUniContext dBContext = new SoftUniContext();

            Console.WriteLine(GetEmployeesFullInformation(dBContext));
            Console.WriteLine(GetEmployeesWithSalaryOver50000(dBContext));
            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(dBContext));
            Console.WriteLine(AddNewAddressToEmployee(dBContext));
            Console.WriteLine(GetEmployeesInPeriod(dBContext));
            Console.WriteLine(GetAddressesByTown(dBContext));
            Console.WriteLine(GetEmployee147(dBContext));
            Console.WriteLine(GetDepartmentsWithMoreThan5Employees(dBContext));
            Console.WriteLine(GetLatestProjects(dBContext));
            Console.WriteLine(IncreaseSalaries(dBContext));
            Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(dBContext));
            Console.WriteLine(DeleteProjectById(dBContext));
            Console.WriteLine(RemoveTown(dBContext));
        }

        // Problem 03 - Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext dbContext)
        {
            // Select the employees columns
            var employees = dbContext.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.MiddleName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.EmployeeId)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        // Problem 04 - Employees with Salary Over 50000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            // Get the employees name and salary
            // where the salary is higher than 50k
            var employees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        // Problem 05 - Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            // Get the employees names, salaries and department name
            var employees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Salary,
                    DepartmentName = x.Department.Name
                })
                .Where(x => x.DepartmentName == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        // Problem 06 - Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            // Create a new address
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            // Find employee with last name 'Nakov'
            Employee nakovEmployee = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            // Add the new address to the 'Addresses' table
            context.Addresses.Add(address);

            // Update Nakov's address
            nakovEmployee.Address = address;

            context.SaveChanges();

            // Take the top 10 employees address text ordered by the address id descending
            string[] employees = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Select(x => x.Address.AddressText)
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (string employeeAddress in employees)
            {
                sb.AppendLine(employeeAddress);
            }

            return sb.ToString().Trim();
        }

        // Problem 07 - Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            // Get the projects, names of the employees, and their managers
            // where the projects start date year is between 2001 / 2003 inclusive
            var employees = context.Employees
                .Include(db => db.EmployeesProjects)
                .ThenInclude(db => db.Project)
                .Where(x => x.EmployeesProjects
                    .Select(x => x.Project)
                    .Any(x => x.StartDate.Year >= 2001 && x.StartDate.Year <= 2003))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects
                        .Select(x => x.Project)
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (Project project in employee.Projects)
                {
                    string endDate = project.EndDate == null
                        ? "not finished"
                        : $"{project.EndDate:M/d/yyyy h:mm:ss tt}";
                    sb.AppendLine($"--{project.Name} - {project.StartDate:M/d/yyyy h:mm:ss tt} - {endDate}");
                }
            }

            return sb.ToString().Trim();
        }

        // Problem 08 - Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            // Get (first 10) the address, town name, and employees in that town
            var addresses = context.Addresses
                .Include(db => db.Employees)
                .Include(db => db.Town)
                .Select(x => new
                {
                    x.AddressText,
                    TownName = x.Town.Name,
                    EmployeesCount = x.Employees.Count()
                })
                .OrderByDescending(x => x.EmployeesCount)
                .ThenBy(x => x.TownName)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return sb.ToString().Trim();
        }

        // Problem 09 - Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            // Find employee 147
            Employee employee = context.Employees
                .Include(db => db.EmployeesProjects)
                .ThenInclude(db => db.Project)
                .FirstOrDefault(x => x.EmployeeId == 147);

            // Get the employees project names
            string[] projectNames = employee.EmployeesProjects
                .Select(x => x.Project.Name)
                .OrderBy(name => name)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (string projectName in projectNames)
            {
                sb.AppendLine(projectName);
            }

            return sb.ToString().Trim();
        }

        // Problem 10 - Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            // Get the department name and manager names
            // where the employee count is higher than 5
            var departments = context.Departments
                .Where(x => x.Employees.Count > 5)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    x.Employees
                })
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.DepartmentName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFirstName} {department.ManagerLastName}");
                foreach (Employee employee in department.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().Trim();
        }

        // Problem 11 - Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            // Get the first 10 projects name, start date, description
            var projects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .Select(x => new
                {
                    x.Name,
                    x.StartDate,
                    x.Description
                })
                .OrderBy(x => x.Name)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}\n{project.Description}\n{project.StartDate:M/d/yyyy h:mm:ss tt}");
            }

            return sb.ToString().Trim();
        }

        // Problem 12 - Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] departmentNames = new string[]
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };

            // Get the employees where their department is in the 'departmentNames' array
            Employee[] employees = context.Employees
                .Where(x => departmentNames.Contains(x.Department.Name))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (Employee employee in employees)
            {
                employee.Salary *= 1.12m; // Increase salary by 12%
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            context.SaveChanges();

            return sb.ToString().Trim();
        }

        // Problem 13 -	Find Employees by First Name Starting with "Sa"
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            // Get the employees names, job title, and salary
            // where their name starts with 'sa'
            var employees = context.Employees
                .Where(x => x.FirstName.ToLower().StartsWith("sa"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);

            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().Trim();
        }

        // Problem 14 - Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            // Find the rows where the project id is 2
            // and delete them
            EmployeeProject[] rowsWithProjectTwo = context.EmployeesProjects
                .Where(x => x.ProjectId == 2)
                .ToArray();
            context.EmployeesProjects.RemoveRange(rowsWithProjectTwo);

            // Find the project where the project id is 2
            // and delete it from the projects table
            Project projectToDelete = context.Projects.Find(2);
            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            Project[] projectList = context.Projects
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (Project project in projectList)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().Trim();
        }

        // Problem 15 - Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            // Get all addresses where the town name is 'Seattle'
            int[] addressesToDelete = context.Addresses
                .Where(x => x.Town.Name == "Seattle")
                .Select(x => x.AddressId)
                .ToArray();

            // Get all employee addresses where the town id exists
            // and are contained in the addressesToDelete array
            int[] employeesAddressesToNull = context.Employees
                .Where(x => x.AddressId.HasValue 
                        && addressesToDelete.Contains(x.AddressId.Value))
                .Select(x => x.EmployeeId)
                .ToArray();

            foreach (Employee employee in context.Employees)
            {
                if (employeesAddressesToNull.Contains(employee.EmployeeId))
                {
                    employee.AddressId = null;
                }
            }

            // Delete the 'Seattle' from the towns and addresses table
            Town townToDelete = context.Towns
                .FirstOrDefault(x => x.Name == "Seattle");
            context.Towns.Remove(townToDelete);
            context.Addresses.RemoveRange(context.Addresses.Where(x => x.Town.Name == "Seattle").ToList());

            context.SaveChanges();

            return $"{addressesToDelete.Length} addresses in Seattle were deleted";
        }
    }
}
