using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Student student = new Student("Gary", "1234");
        Schedule schedule = new Schedule(student);

        Bool keepRunning = true;
        {
            while (keepRunning)
            {
                Console.WriteLine("1. display");
                Console.WriteLine("2. Add Course");
                Console.WriteLine("Choose");

                string response = Console.ReadLine();

                if (response == 1)
                {
                    schedule.Display();
                }
                else if (response == 2)
                {
                    Console.WriteLine("Course Number?: ");
                    string courseNumber = Console.ReadLine();
                    Course course = new Course(courseNumber, 0, 0, "M/W");
                    // some line of code i missed from class
                }
            }
        }
    }
}