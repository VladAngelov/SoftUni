namespace SoftUni
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            // 03
            Console.WriteLine(GetEmployeesFullInformation(context));

            // 04
            Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

            // 05
            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

            // 06
            Console.WriteLine(AddNewAddressToEmployee(context));

            // 07
            Console.WriteLine(GetEmployeesInPeriod(context));

            // 08
            Console.WriteLine(GetAddressesByTown(context));

            // 09
            Console.WriteLine(GetEmployee147(context));

            // 10
            Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));

            // 11
            Console.WriteLine(GetLatestProjects(context));

            // 12
            Console.WriteLine(IncreaseSalaries(context));

            // 13
            Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));

            // 14
            Console.WriteLine(DeleteProjectById(context));

            // 15
            Console.WriteLine(RemoveTown(context));
        }

        #region Problem 03 Employees Full Information 
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(x => x.EmployeeId);

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} " +
                              $"{employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
        #endregion

        #region Problem 04 Employees with Salary Over 50 000 
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(x => x.FirstName)
                .Where(s => s.Salary > 50000);

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
        #endregion

        #region Problem 05 Employees from Research and Development 
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                    .Include(x => x.Department)
                    .Where(x => x.Department.Name == "Research and Development")
                    .OrderBy(x => x.Salary)
                    .ThenByDescending(x => x.FirstName)
                    .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName}" +
                              $" from {employee.Department.Name} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
        #endregion

        #region Problem 06 Adding a New Address and Updating Employee 
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee nakov = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            nakov.Address = address;

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            List<string> employeeAddresses = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Select(a => a.Address.AddressText)
                .Take(10)
                .ToList();

            foreach (string employeeAddress in employeeAddresses)
            {
                sb.AppendLine($"{employeeAddress}");
            }

            return sb.ToString().TrimEnd();
        }
        #endregion

        #region Problem 07 Employees and Projects 
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(p => p.EmployeesProjects
                        .Any(s => s.Project.StartDate.Year >= 2001 &&
                                 s.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    EmployeeFullName = x.FirstName + " " + x.LastName,
                    ManagerFullName = x.Manager.FirstName + " " + x.Manager.LastName,
                    Projects = x.EmployeesProjects
                                .Select(p => new
                                {
                                    ProjectName = p.Project.Name,
                                    StartDate = p.Project.StartDate,
                                    EndDate = p.Project.EndDate
                                })
                        .ToList()
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeFullName} - Manager: {employee.ManagerFullName}");

                foreach (var project in employee.Projects)
                {
                    string startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt");

                    string endDate = project.EndDate.HasValue ?
                        project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                        : "not finished";

                    sb.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        #endregion

        #region Problem 8 Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Include(t => t.Town)
                .Include(e => e.Employees)
                .OrderByDescending(e => e.Employees.Count)
                .ThenBy(t => t.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Town.Name}" +
                              $" - {address.Employees.Count} employees");
            }

            return sb.ToString().TrimEnd();
        }
        #endregion

        #region Problem 9 Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var currentEmployee = context.Employees
                .Include(ep => ep.EmployeesProjects)
                .ThenInclude(p => p.Project)
                .Where(e => e.EmployeeId == 147)
                .SingleOrDefault();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{currentEmployee.FirstName} {currentEmployee.LastName} - {currentEmployee.JobTitle}");

            foreach (var cEmpPr in currentEmployee.EmployeesProjects.OrderBy(x => x.Project.Name))
            {
                sb.AppendLine(cEmpPr.Project.Name);
            }

            return sb.ToString().TrimEnd();
        }
        #endregion

        #region Problem 10 Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(e => e.Employees.Count > 5)
                .OrderBy(e => e.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerFullName = x.Manager.FirstName + " " + x.Manager.LastName,
                    Employees = x.Employees.Select(e => new
                    {
                        EmployeeFullName = e.FirstName + " " + e.LastName,
                        JobTitle = e.JobTitle
                    })
                        .OrderBy(f => f.EmployeeFullName)
                        .ToList()
                });

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFullName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.EmployeeFullName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        #endregion

        #region Problem 11 Find Latest 10 Projects 
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }
        #endregion

        #region Problem 12 Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departmentsName = new[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                .Include(x => x.Department)
                .Where(d => departmentsName.Contains(d.Department.Name))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary += employee.Salary * 0.12m;
            }

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }
        #endregion

        #region Problem 13 Find Employees by First Name Starting With Sa 
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => EF.Functions.Like(e.FirstName, "sa%"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(f => f.FirstName)
                .ThenBy(f => f.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }
        #endregion

        #region Problem 14 Delete Project by Id 
        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects
                .FirstOrDefault(x => x.ProjectId == 2);

            var employeeProjects = context.EmployeesProjects
                .Where(x => x.ProjectId == 2)
                .ToList();

            context.EmployeesProjects.RemoveRange(employeeProjects);

            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects
                .Select(x => x.Name)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var currentProject in projects)
            {
                sb.AppendLine(currentProject);
            }

            return sb.ToString().TrimEnd();
        }
        #endregion

        #region Problem 15 Remove Town 
        public static string RemoveTown(SoftUniContext context)
        {
            var addressForRemove = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList();

            foreach (var employee in context.Employees)
            {
                if (addressForRemove.Contains(employee.Address))
                {
                    employee.Address = null;
                }
            }

            context.Addresses.RemoveRange(addressForRemove);

            context.SaveChanges();

            var removedAddressesCount = addressForRemove.Count;

            var addressSingleOrPlural = removedAddressesCount > 1 ? "addresses" : "address";

            var wasWere = removedAddressesCount > 1 ? "were" : "was";

            string result = $"{removedAddressesCount} {addressSingleOrPlural} in Seattle {wasWere} deleted";

            return result;
        }
        #endregion
    }
}