using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillTestASP.Models;
using System.Text.RegularExpressions;
using SkillTestASP.Models.Dtos;
using Microsoft.Data.SqlClient;
using Dapper;

namespace SkillTestASP.Controllers
{
    public class SQLController : Controller
    {
        public IActionResult Index()
        {


            using var connection = new SqlConnection("Server=(localdb)\\ProjectModels;database=Database1;Trusted_Connection=True;");
            var countQuery = connection.Query<SQLCountDto>(
                "SELECT department, COUNT(department) AS Count FROM employee GROUP BY Department");

            ViewData["departmentCountData"] = countQuery;


            //var hmm1 = connection.Execute("INSERT INTO Database2.dbo.Employee2(Id,Employee) SELECT DISTINCT " +
            //    "Employee.Id, Employee.Name FROM Employee RIGHT JOIN Experience ON Employee.Id = Experience.EmployeeId");


            var transferData = connection.Query<Employee2>("Select * FROM  Database2.dbo.Employee2");
            ViewData["transferData"] = transferData;

            var salaryCheck = connection.Query<SalaryGreaterThanEstDto>(
                "SELECT Id, Name, Total_Salary, YearlyEstimatedSalary FROM Employee AS e "
                + "FULL JOIN "
                + "(SELECT EmployeeId, SUM(SALARY) AS Total_Salary FROM Salary GROUP BY EmployeeId ) AS s "
                + "ON e.Id = s.EmployeeId "
                + "WHERE Total_Salary > YearlyEstimatedSalary ");

            ViewData["salaryData"] = salaryCheck;
            return View();
            
        }

       
    }
}
