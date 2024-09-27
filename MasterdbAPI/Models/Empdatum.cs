using System;
using System.Collections.Generic;

namespace MasterdbAPI.Models;

public partial class Empdatum
{
    public string Name { get; set; } = null!;

    public int Empid { get; set; }

    public int Salary { get; set; }

    public string Deptid { get; set; } = null!;

    public string? Dname { get; set; }
}
