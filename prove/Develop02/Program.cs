using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Load entries from file");
            Console.WriteLine("4. Save entries to file");
            Console.WriteLine("5. Quit");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Entry entry = new Entry();
                entry.Prompt(); // Ask random prompt and store response
                // myJournal.newEntry(entry); // save it to journal
                Console.WriteLine("Entry added!");
            }

            else if (choice == "2")
            {
                myJournal.DisplayEntries();
            }

            else if (choice == "3")
            {
                // Load saved entries from file
                myJournal.Load();
            }

            else if (choice == "4")
            {
                // save entries to file
                myJournal.Save();
            }

            else if (choice == "5")
            {
                running = false;
            }

            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }
    }
}