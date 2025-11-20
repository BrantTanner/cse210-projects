class SimpleGoal : Goal
{
    public SimpleGoal(string goalType) : base (goalType)
    {
        
    }
    public SimpleGoal(string csvLine): base (csvLine)
    {

    }

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