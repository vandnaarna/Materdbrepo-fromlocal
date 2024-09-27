using System;
using System.Collections.Generic;

namespace MasterdbAPI.Models;

public partial class Master
{
    public int Pid { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Contactno { get; set; }

    public string? City { get; set; }

    public decimal? Pincode { get; set; }

    public string? Emai { get; set; }
}
