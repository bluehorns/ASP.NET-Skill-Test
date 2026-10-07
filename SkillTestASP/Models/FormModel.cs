namespace SkillTestASP.Models
{
    public class FormModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Department { get; set; }

        public decimal YearlyEstimatedSalary { get; set; }

        public string[]? CompanyName { get; set; }

        public int[]? Years { get; set; }


        public Employee createEmployee()
        {
            return new Employee()
            {
                Name = this.FirstName + " " + this.LastName,
                Department = this.Department,
                YearlyEstimatedSalary = this.YearlyEstimatedSalary,
                CreatedDate = DateTime.Today

            };
        }

        public ICollection<Experience> createExperience(int employeeId)
        {
            ICollection<Experience> experienceList = new List<Experience>();
            for (int i = 0;i< CompanyName.Length;i++)
            {
                experienceList.Add(new Experience()
                {
                    EmployeeId = employeeId,
                    CompanyName = this.CompanyName[i],
                    Years = this.Years[i]
                });
            }

            return experienceList;
        }



    }
}
