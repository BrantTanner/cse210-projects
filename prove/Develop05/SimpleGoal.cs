class SimpleGoal : Goal
{
    public SimpleGoal() : base ("simple")
    {
        
    }
    public SimpleGoal(string csvLine): base (csvLine, true)
    {

    }

    // overridden method for completing goals
    public override void CompleteGoal()
    {
        if (!_complete)
        {
            _complete = true;
            _totalPoints += _goalPoints;
            Console.WriteLine($"Congrats you completed a simple goal! You earned {_goalPoints} points! Your total score is {_totalPoints}");
        }
        else
        {
            Console.WriteLine("This goal is already complete.");
        }
    }
}