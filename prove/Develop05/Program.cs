using System;
using System.ComponentModel.DataAnnotations.Schema;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        List<Goal> uncompletedGoals = new List<Goal>();

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

            if (!int.TryParse(userInput, out int usrChoice))
            {
                Console.WriteLine("Invalid input. Please enter a number (1-4). \n");
                continue;
            }

            if (usrChoice == 1)
            {
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
                    goals.Add(new SimpleGoal("simple"));
                }
                if(goalTypeChoice == 2)
                {
                    goals.Add(new EternalGoal("eternal"));
                }
                if(goalTypeChoice == 3)
                {
                    goals.Add(new ChecklistGoal("checklist"));
                }   
            }
            else if (usrChoice == 2)
            {
                
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
                    Console.WriteLine($"{checkbox} {numberedlist}. {goal.GoalName} - {goal.GoalDescription}");
                    numberedlist ++;
                }
            }
            else if (usrChoice == 3)
            {
                
            }
            else if (usrChoice == 4)
            {
                
            }
            else if (usrChoice == 5)
            {
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
                break;
            }
            else
            {
                Console.WriteLine($"{usrChoice} is an invalid input, Please enter a number (1-5). \n");
            };
        }
    }
};