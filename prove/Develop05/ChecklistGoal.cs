class ChecklistGoal : Goal
{
    private int _completionCounter;
    private int _desiredGoalCount;
    private int _bonusPoints;

    // constructors for create checklist goal and saving it with extra parts
    public ChecklistGoal(): base("checklist")
    {
        _completionCounter = 0;

        Console.WriteLine("How many times do you wish to complete this goal?: ");
        _desiredGoalCount = int.Parse(Console.ReadLine());

        Console.WriteLine($"How many bonus points is this worth by completing {_desiredGoalCount} times?: ");
        _bonusPoints = int.Parse(Console.ReadLine());
    }

    public ChecklistGoal(string csvLine) : base(csvLine, true)
    {
        var parts = csvLine.Split('|');

        _completionCounter = int.Parse(parts[6]);
        _desiredGoalCount = int.Parse(parts[7]);
        _bonusPoints = int.Parse(parts[8]);
    }

    // Getter to display remaing attempts for checklist goals
    public int GetRemainingGoals()
    {
        return  _desiredGoalCount - _completionCounter;
    }

    public override string ToCSV()
    {
        // Include base fields then subclass fields
        return base.ToCSV() + $"|{_completionCounter}|{_desiredGoalCount}|{_bonusPoints}";
    }

    // Overridden method for completing goals
    public override void CompleteGoal()
    {
        if (!_complete)
        {
             _completionCounter++;
    
            if(_completionCounter != _desiredGoalCount)
            {
                _totalPoints += _goalPoints;
                Console.WriteLine($"Congrats you have completed a Checklist goal! You have earned {_goalPoints} points! Your total score is {_totalPoints}, Complete this goal {_desiredGoalCount - _completionCounter} more times to earn bonus points :)");
            }
            else
            {
                _complete = true;
                _totalPoints += _goalPoints + _bonusPoints;
                Console.WriteLine($"WOOP! WOOP! You just completed a Checklist Goal your desired amount of times({_desiredGoalCount}). You get {_goalPoints} points and {_bonusPoints} bonus points!");
            }
        }
        else
        {
        Console.WriteLine("This goal is already complete.");
        }
    }

    public override void DisplayGoal()
    {
        string checkbox;
        if(_complete == true)
        {
            checkbox = "[X]";
        }
        else
        {
            checkbox = "[ ]";
        }

        Console.WriteLine($"{checkbox} {_goalName} - {_goalDescription} ({GetRemainingGoals()})");
    }
}