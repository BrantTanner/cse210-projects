using System.Security.Cryptography;

abstract class  Goal
{
    protected string _goalType;
    protected int _totalPoints;
    protected string _goalName;
    protected string _goalDescription;
    protected int _goalPoints;
    protected bool _complete;


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

    public bool GetComplete()
    {
        return _complete;
    }

    public int GetTotalPoints()
    {
        return _totalPoints;
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