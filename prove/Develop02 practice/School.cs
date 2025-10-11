public class School
{

    public int _numStudents;

    public int _numTeachers;

    public string _name;

    public List<Student> _students;

    public void Register()
    {
        // do something??
    }

    public void ShowDetails()
    {
        Console.WriteLine($"School: {_name} Number of students: {_numStudents} Number of: {_numTeachers}");

        foreach (Student theStudent in _students)
        {
            Console.WriteLine(theStudent.GetName());
        }
    }
}