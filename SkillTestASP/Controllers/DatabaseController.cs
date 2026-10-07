using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillTestASP.Models;
using System.Collections;

namespace SkillTestASP.Controllers
{
    public class DatabaseController : Controller
    {
         IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

        public IActionResult Index()
        {
            List<Employee> employeeList = new List<Employee>();
            using (var dbcontext = new Database1Context(configuration))
            {
                employeeList = dbcontext.Employees.Include(exp => exp.Experiences).ToList();
            }
            
            ViewData["EmployeeData"] = employeeList;
            return View();
        }

       

        
    }
}
