using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {   // Breathing Activity 
        Breathing breathingActivity = new Breathing("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 0);

        

        //Refelction Activity
        List<string> prompts = new List<string>
        {
            " --- Think of a time when you stood up for someone else. --- ",
            " --- Think of a time when you did something really difficult. --- ",
            " --- Think of a time when you helped someone in need. --- ",
            " --- Think of a time when you did something truly selfless. --- "
        };

        List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
        };

        Reflection reflectingActivity = new Reflection("Reflection Activity", "This Activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 0, prompts, questions);

        //Listing Activity
        List<string> listingPrompts = new List<string>
        {
            " --- Who are people that you appreciate? --- ",
            " --- What are personal strengths of yours? --- ",
            " --- Who are people that you have helped this week? --- ",
            " --- When have you felt the Holy Ghost this month? --- ",
            " --- Who are some of your personal heroes? --- "
        };

        Listing listingActivity = new Listing("Listing Activity", "This Activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 0, listingPrompts);

        while (true)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start breathing activity");
            Console.WriteLine(" 2. Start reflecting activity");
            Console.WriteLine(" 3. Start listing activity");
            Console.WriteLine(" 4. Quit");
            Console.Write("Select a choice from the menu: ");

            string userInput = Console.ReadLine();

            if (!int.TryParse(userInput, out int usrChoice))
            {
                Console.WriteLine("Invalid input. Please enter a number (1-4). \n");
                continue;
            }

            if (usrChoice == 1)
            {
                breathingActivity.RunActivity();
            }
            else if (usrChoice == 2)
            {
                reflectingActivity.RunActivity();
            }
            else if (usrChoice == 3)
            {
                listingActivity.RunActivity();
            }
            else if (usrChoice == 4)
            {
                break;
            }
            else
            {
                Console.WriteLine($"{usrChoice} is an invalid input, Please enter a number (1-4). \n");
            }


            
        }
    }
}