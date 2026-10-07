using System;
using System.Collections.Generic;

namespace SkillTestASP.Models;

public partial class Experience
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string CompanyName { get; set; } = null!;

    public int Years { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
