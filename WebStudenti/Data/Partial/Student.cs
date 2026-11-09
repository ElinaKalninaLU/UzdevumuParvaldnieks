namespace WebStudenti.Data.Students;

public partial class Student
{
    public string FullName => Name + " " + Surname;
}
