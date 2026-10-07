using System;
using System.Collections.Generic;

namespace SkillTestASP.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Department { get; set; } = null!;

    public decimal YearlyEstimatedSalary { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();

    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();
}
