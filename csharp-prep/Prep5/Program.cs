using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();

        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favNum = int.Parse(Console.ReadLine());

        return favNum;
    }

    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        int numSquared = number * number;

        return numSquared;
    }

    static void DisplayResult(string usrName, int numSquared, int birthYear)
    {
        int age = 2025 - birthYear;
        Console.WriteLine($"{usrName}, the square of your number is {numSquared}");
        Console.WriteLine($"{usrName}, you will turn {age} this year");
    }

    static void Main(string[] args)
    {
        DisplayWelcome();
        string usrName = PromptUserName();
        int usrNumber = PromptUserNumber();
        PromptUserBirthYear(out int birthYear);
        int sqrdNum = SquareNumber(usrNumber);
        DisplayResult(usrName, sqrdNum, birthYear);
        
    }
}