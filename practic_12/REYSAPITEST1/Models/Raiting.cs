using System;
using System.Collections.Generic;

namespace REYSAPITEST1.Models;

public partial class Raiting
{
    public int? IdRaiting { get; set; }

    public string Email { get; set; } = null!;

    public int Application { get; set; }

    public double? Value { get; set; }
}
