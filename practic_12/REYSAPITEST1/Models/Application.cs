using System;
using System.Collections.Generic;

namespace REYSAPITEST1.Models;

public partial class Application
{
    public int? IdApplication { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public byte[]? Image { get; set; }

    public string? Description { get; set; }
}
