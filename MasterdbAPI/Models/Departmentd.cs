using System;
using System.Collections.Generic;

namespace MasterdbAPI.Models;

public partial class Departmentd
{
    public string Depid { get; set; } = null!;

    public string? Dname { get; set; }

    public string Dloc { get; set; } = null!;
}
