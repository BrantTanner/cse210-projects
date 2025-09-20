using System;

class Program
{
    static void Main(string[] args)
    {
        string grade = "";

        Console.Write("Please enter you grade percentage: ");
        string valueFromUser = Console.ReadLine();

        int gradePercent = int.Parse(valueFromUser);

        if (gradePercent >= 90)
        {
            grade = "A";
        }

        else if (gradePercent >= 80)
        {
            grade = "B";
        }

        else if (gradePercent >= 70)
        {
            grade = "C";
        }

        else if (gradePercent >= 60)
        {
            grade = "D";
        }

        else
        {
            grade = "F";
        }

        Console.WriteLine($"Your grade is {grade}");

        if (gradePercent >= 70)
        {
            Console.WriteLine("You passed!");
        }

        else
        {
            Console.WriteLine("You failed...");
        }
    }
}