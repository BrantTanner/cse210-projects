abstract class  Goal
{
    protected string _goalType;
    protected int _totalPoints;
    protected string _goalName;
    protected string _goalDescription;
    protected int _goalPoints;
    protected bool _complete;

    public string GoalName => _goalName;
    public string GoalDescription => _goalDescription;
    public int GoalPoints => _goalPoints;
    public bool Complete => _complete;
    public string GoalType => _goalType;

    public Goal(string goalType)
    {
        Console.WriteLine("What is the Name of this goal?: ");
        _goalName = Console.ReadLine();

        Console.WriteLine("What is a short description of this goal?: ");
        _goalDescription = Console.ReadLine();

        Console.WriteLine("How many points is this goal worth?: ");
        _goalPoints = int.Parse(Console.ReadLine());

      
        _goalType = goalType;

        _complete = false;
    }

     public Goal(string csvLine)
    {
        var parts = csvLine.Split('|');
        _goalType = parts[0];
        _goalName = parts[1];
        _goalDescription = parts[2];
        _complete = bool.Parse(parts[3]);
    }

    public virtual string ToCSV()
    {
        return $"{GoalType}|{GoalName}|{GoalDescription}|{Complete}";
    }
    public abstract void CompleteGoal();

};