using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        string scriptureStr = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        string referenceStr = "Proverbs 3:5-6";


        string[] scriptureList = scriptureStr.Split();

        Scripture scripture = new Scripture(scriptureList, referenceStr);


        while (running)
        {


            scripture.Display();
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            string userChoice = Console.ReadLine();

            running = scripture.ChooseWordsToHide();
            if (userChoice == "quit")
            {
                running = false;
            }
            Console.Clear();

        }

    }
}