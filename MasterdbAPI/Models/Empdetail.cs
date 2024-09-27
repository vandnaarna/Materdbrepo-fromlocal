using System;
using System.Collections.Generic;

namespace MasterdbAPI.Models;

public partial class Empdetail
{
    public string Name { get; set; } = null!;

    public int Empid { get; set; }

    public int Salary { get; set; }

    public int Deptid { get; set; }

    public string? Dname { get; set; }
}
