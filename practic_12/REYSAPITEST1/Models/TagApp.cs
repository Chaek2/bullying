using System;
using System.Collections.Generic;

namespace REYSAPITEST1.Models;

public partial class TagApp
{
    public int? IdTagApp { get; set; }

    public string Tag { get; set; } = null!;

    public int Application { get; set; }
}