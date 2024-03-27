using System;
using System.Collections.Generic;

namespace REYSAPITEST1.Models;

public partial class Person
{
    public string Email { get; set; } = null!;

    public int? Identifier { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public bool? Verified { get; set; }

    public string Post { get; set; } = null!;

    public string? Image { get; set; }
}
