using System;
using System.Collections.Generic;

namespace WebStudenti.Data.Students;

public partial class Grade
{
    public int? ExaminationId { get; set; }

    public int? StudentId { get; set; }

    public int? GradingTeacherId { get; set; }

    public int? Grade1 { get; set; }

    public virtual Examination? Examination { get; set; }

    public virtual Teacher? GradingTeacher { get; set; }

    public virtual Student? Student { get; set; }
}
