using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop02 World!");

        School school1 = new School();
        school1._name = "BYU-I";
        school1._numStudents = 32000;
        school1._numTeachers = 500;

        Student student1 = new Student();
        student1._name = "Bill Alexander";

        school1._students = new List<Student>();
        school1._students.Add(student1);

        school1.ShowDetails();

        School school2 = new School();
        school1._name = "BYU Provo";
        school1._numStudents = 50000;
        school1._numTeachers = 1000;

        school2.ShowDetails();
    }
}