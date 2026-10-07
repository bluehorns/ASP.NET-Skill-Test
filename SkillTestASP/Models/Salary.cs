using System;
using System.Collections.Generic;

namespace SkillTestASP.Models;

public partial class Salary
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string Month { get; set; } = null!;

    public decimal Salary1 { get; set; }

    public virtual Employee Employee { get; set; } = null!;


}
