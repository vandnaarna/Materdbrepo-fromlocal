using System;
using System.Collections.Generic;

namespace MasterdbAPI.Models;

public partial class Product
{
    public string Productid { get; set; } = null!;

    public string Productname { get; set; } = null!;

    public int Promrp { get; set; }

    public int? Productno { get; set; }
}
