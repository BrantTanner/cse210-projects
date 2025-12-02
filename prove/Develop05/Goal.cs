abstract class  Goal
{
    protected string _goalType;
    protected int _totalPoints;
    protected string _goalName;
    protected string _goalDescription;
    protected int _goalPoints;
    protected int _pointsLevel;
    protected bool _complete;

    // Display only versions of member variables for menu
    public string GoalName => _goalName;
    public string GoalDescription => _goalDescription;
    public int GoalPoints => _goalPoints;
    public bool Complete => _complete;
    public string GoalType => _goalType;
    public int TotalPoints => _totalPoints;

    // Constructors for creating goal and saving them
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

     public Goal(string csvLine, bool fromCSV)
    {
        var parts = csvLine.Split('|');
        
        _goalType = parts[0];
        _goalName = parts[1];
        _goalDescription = parts[2];
        _goalPoints = int.Parse(parts[3]);
        _complete = bool.Parse(parts[4]);
        _totalPoints = int.Parse(parts[5]);
    }


    public virtual string ToCSV()
    {
        return $"{_goalType}|{_goalName}|{_goalDescription}|{_goalPoints}|{_complete}|{_totalPoints}";
    }
    public abstract void CompleteGoal();

   public abstract void DisplayGoal();

};