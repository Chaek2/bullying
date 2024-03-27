using System;
using System.Collections.Generic;

namespace REYSAPITEST1.Models;

public partial class CategoryApp
{
    public int? IdCategoryApp { get; set; }

    public string Category { get; set; } = null!;

    public int Application { get; set; }
}
