using System;
using System.Collections.Generic;

namespace WebStudenti.Data.Students;

public partial class Student
{
    public int StudentId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}
