using System;

class Program
{
    static void Main(string[] args)
    {
        string response = "yes";

        while (response == "yes")
        {
            Console.Write('Do you want to continue? ');
            response = Console.ReadLine();
        }
    }
}