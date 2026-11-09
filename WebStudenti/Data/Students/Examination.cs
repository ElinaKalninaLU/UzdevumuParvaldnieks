using System;
using System.Collections.Generic;

namespace WebStudenti.Data.Students;

public partial class Examination
{
    public int ExaminationId { get; set; }

    public int? CourseId { get; set; }

    public int? ResponsibleTeacherId { get; set; }

    public DateTime? Date { get; set; }

    public string? Description { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Teacher? ResponsibleTeacher { get; set; }
}
