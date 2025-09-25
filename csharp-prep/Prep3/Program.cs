using System;

class Program
{
    static void Main(string[] args)
    {
        // string response = "yes";

        // while (response == "yes")
        // {
        //     Console.Write("Do you want to continue? ");
        //     response = Console.ReadLine();
        // }
        // do
        // {
        //     Console.Write("Do you want to continue? ");
        //     response = Console.ReadLine();
        // } while (response == "yes");
        // for (int i = 0; i < 10; i++)
        // {
        //     Console.WriteLine(i);
        // }
        // foreach (string color in colors)
        // {
        //     Console.WriteLine(color);
        // }



        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);

        int userGuess = -2;

       

        //game loop
        do
        {
            Console.Write("What is the magic number? ");
            userGuess = int.Parse(Console.ReadLine());

            if (userGuess == number)
            {
                Console.WriteLine("Wow! you guessed the number");
            }
            else if (userGuess > number)
            {
                Console.WriteLine("Lower");
            }
            else if (userGuess < number)
            {
                Console.WriteLine("Higher");
            }
        } while (userGuess != number);
    }   
}