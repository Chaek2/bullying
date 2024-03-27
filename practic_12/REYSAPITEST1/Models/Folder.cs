using System;
using System.Collections.Generic;

namespace REYSAPITEST1.Models;

public partial class Folder
{
    public int? IdFolder { get; set; }

    public string Email { get; set; } = null!;

    public string Title { get; set; } = null!;
}
