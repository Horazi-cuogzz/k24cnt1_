using System;
using System.Collections.Generic;

namespace PhungQuangCuong2410900015_exam.Models;

public partial class PqcStudent
{
    public int Id { get; set; }

    public string PqcName { get; set; } = null!;

    public bool? PqcGender { get; set; }

    public DateOnly? PqcBirthDay { get; set; }

    public string? PqcEmail { get; set; }

    public string? PqcPhone { get; set; }

    public bool? PqcActive { get; set; }
}
