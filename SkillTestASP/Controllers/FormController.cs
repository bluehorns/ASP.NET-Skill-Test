using Microsoft.AspNetCore.Mvc;
using SkillTestASP.Models;

namespace SkillTestASP.Controllers
{ 

    public class FormController : Controller
    {
        IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessForm(FormModel formModel)
        {

            using (var dbcontext = new Database1Context(configuration))
            {
                var tempEmployee = formModel.createEmployee();
                dbcontext.Employees.Add(tempEmployee);
                dbcontext.SaveChanges();

                int employeeId = tempEmployee.Id;
                var experienceList = formModel.createExperience(employeeId);
                foreach (Experience experience in experienceList)
                {
                    dbcontext.Experiences.Add(experience);
                }

                dbcontext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

      
    }
}
