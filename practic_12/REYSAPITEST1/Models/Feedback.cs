using System;
using System.Collections.Generic;

namespace REYSAPITEST1.Models;

public partial class Feedback
{
    public int? IdFeedback { get; set; }

    public string Email { get; set; } = null!;

    public int Application { get; set; }

    public string Message { get; set; } = null!;

    public DateTime Dates { get; set; }

    public int? Answer { get; set; }
}
