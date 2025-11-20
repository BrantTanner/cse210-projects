using System;
using System.ComponentModel.DataAnnotations.Schema;

class Program
{
    static void Main(string[] args)
    {
        // List objects
        List<Goal> goals = new List<Goal>();
        List<Goal> uncompletedGoals = new List<Goal>();

        // Menu loop
        while (true)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6 . Quit");
            Console.Write("Select a choice from the menu: ");

            string userInput = Console.ReadLine();

            // Menu Protection
            if (!int.TryParse(userInput, out int usrChoice))
            {
                Console.WriteLine("Invalid input. Please enter a number (1-4). \n");
                continue;
            }

            if (usrChoice == 1)
            {   
                // Nested If statement to decide which goal should it create
                Console.WriteLine("What type of goal do you wish to create?:");
                Console.WriteLine(" 1. Simple Goal");
                Console.WriteLine(" 2. Eternal Goal");
                Console.WriteLine(" 3. Checklist Goal");

                string goalTypeInput = Console.ReadLine();
                if (!int.TryParse(goalTypeInput, out int goalTypeChoice))
                {
                    Console.WriteLine("Invalid input. Please enter a number (1-3). \n");
                    continue;
                }
                if(goalTypeChoice == 1)
                {
                    goals.Add(new SimpleGoal());
                }
                if(goalTypeChoice == 2)
                {
                    goals.Add(new EternalGoal());
                }
                if(goalTypeChoice == 3)
                {
                    goals.Add(new ChecklistGoal());
                }   
            }
            else if (usrChoice == 2)
            {
                // List Goals and Total Points
                Console.WriteLine("Your goals: ");
                int numberedlist = 1;
                string checkbox;

                foreach (var goal in goals){
                    if(goal is EternalGoal)
                    {
                        checkbox = "[-]";
                    }
                    else if(goal.Complete == true)
                    {
                        checkbox = "[X]";
                    }
                    else
                    {
                        checkbox = "[ ]";
                    }
                    if(goal is ChecklistGoal checklist)
                    {
                        Console.WriteLine($"{checkbox} {numberedlist}. {goal.GoalName} - {goal.GoalDescription} ({checklist.GetRemainingGoals()})");
                        numberedlist ++;
                        continue;
                    }
                    else
                    {
                        
                        Console.WriteLine($"{checkbox} {numberedlist}. {goal.GoalName} - {goal.GoalDescription}");
                        numberedlist ++;
                    }     
                }
                int overallTotal = goals.Sum(g => g.TotalPoints);
                int overallLevel = overallTotal / 1000;
                Console.WriteLine($"Total Points: {overallTotal}");
                Console.WriteLine($"Your Level: {overallLevel}");
                Console.WriteLine("you level up every 1000 points earned!");
            }
            else if (usrChoice == 3)
            {
                // Save Goals to text file
                using (StreamWriter writer = new StreamWriter("goals.txt"))
                {
                    foreach (var g in goals)
                    {
                        writer.WriteLine(g.ToCSV());
                    }
                }
                Console.WriteLine("Goals saved!");
            }
            else if (usrChoice == 4)
            {
                // Load goals from text file (added protection if there is no file)
                if (!File.Exists("goals.txt"))
                {
                    Console.WriteLine("No goals saved yet.");
                    continue;
                }

                goals.Clear();
                string[] lines = File.ReadAllLines("goals.txt");

                foreach (string line in lines)
                {
                    string type = line.Split('|')[0];

                    if(type == "simple")
                        goals.Add(new SimpleGoal(line));
                    else if (type == "eternal")
                        goals.Add(new EternalGoal(line));
                    else if (type == "checklist")
                        goals.Add(new ChecklistGoal(line));
                }

                Console.WriteLine("Goals loaded!");
                
                // Display goals after they are loaded from file
                Console.WriteLine("Your goals: ");
                int numberedlist = 1;
                string checkbox;
                foreach (var goal in goals){
                    if(goal is EternalGoal)
                    {
                        checkbox = "[-]";
                    }
                    else if(goal.Complete == true)
                    {
                        checkbox = "[X]";
                    }
                    else
                    {
                        checkbox = "[ ]";
                    }
                    if(goal is ChecklistGoal checklist)
                    {
                        
                        Console.WriteLine($"{checkbox} {numberedlist}. {goal.GoalName} - {goal.GoalDescription} ({checklist.GetRemainingGoals()})");
                        numberedlist ++;
                    }
                    else
                    {
                        Console.WriteLine($"{checkbox} {numberedlist}. {goal.GoalName} - {goal.GoalDescription}");
                        numberedlist ++;
                    } 
                int overallTotal = goals.Sum(g => g.TotalPoints);
                int overallLevel = overallTotal / 1000;
                Console.WriteLine($"Total Points: {overallTotal}");
                Console.WriteLine($"Your Level: {overallLevel}");
                Console.WriteLine("you level up every 1000 points earned!");
                }
            }
            else if (usrChoice == 5)
            {
                // Record event to complete a goal
                uncompletedGoals.Clear();
                foreach(var goal in goals)
                {
                    if (goal.Complete == false)
                    {
                        uncompletedGoals.Add(goal);
                    }
                }

                Console.WriteLine("Here is a list of your uncompleted goals");
                int numberedlist = 1;

                foreach (var goal in uncompletedGoals)
                {
                    Console.WriteLine($"[ ] {numberedlist}. {goal.GoalName} - {goal.GoalDescription}");
                    numberedlist ++;
                }
                Console.WriteLine("Enter the number of what goal you completed: ");
                int userInputtedGoal = int.Parse(Console.ReadLine());
                int index = userInputtedGoal - 1;
                Goal completedGoal = uncompletedGoals[index];
                completedGoal.CompleteGoal();
            }
            else if (usrChoice == 6)
            {
                // Quit program
                break;
            }
            else
            {
                Console.WriteLine($"{usrChoice} is an invalid input, Please enter a number (1-5). \n");
            };
        }
    }
};