using System;
using System.Collections.Generic;

namespace REYSAPITEST1.Models;

public partial class Version
{
    public int? IdVersion { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Path { get; set; } = null!;
}