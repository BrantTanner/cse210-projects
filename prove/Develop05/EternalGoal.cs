class EternalGoal : Goal
{
    private int _completionCounter;
    public EternalGoal(): base("eternal")
    {
        _completionCounter = 0;
    }
    public EternalGoal(string cvsLine) : base(cvsLine, true)
    {
        _complete = false;
    }

    // overridden method for completing goals
    public override void CompleteGoal()
    {
        _completionCounter ++;
        _totalPoints += _goalPoints;
        Console.WriteLine("Congrats you complete an eternal goal!");
        Console.WriteLine($"You have completed this goal {_completionCounter} times, and earned {_goalPoints} points! Your total score is {_totalPoints} ");
    }
}
