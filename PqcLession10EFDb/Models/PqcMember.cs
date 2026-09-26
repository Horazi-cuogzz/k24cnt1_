using System;
using System.Collections.Generic;

namespace PqcLession10EFDb.Models;

public partial class PqcMember
{
    public long Id { get; set; }

    public string? PqcUserName { get; set; }

    public string? PqcPassword { get; set; }

    public string? PqcFullName { get; set; }

    public string? PqcEmail { get; set; }

    public string? PqcPhone { get; set; }

    public bool? PqcStatus { get; set; }
}
