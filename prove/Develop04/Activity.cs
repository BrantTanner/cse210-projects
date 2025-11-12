public class Activity
{
    protected string _activityName;
    protected string _activityDescription;
    protected int _durationSecs = 0;
    protected Animation _animation;

    public Activity(string activityName, string activityDescription)
    {
        _activityName = activityName;
        _activityDescription = activityDescription;
        _animation = new Animation();

    }

    public void CountDownTimer(int duration)
    {
        for (int i = duration; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void DisplayStartMessage()
    {
        Console.WriteLine($"Welcome to the {_activityName}");
        Console.WriteLine(" ");
        Console.WriteLine(_activityDescription);
        Console.WriteLine(" ");
    }

    public void GetDuration()
    {
        Console.Write("How long, in seconds, would you like for you session? ");
        _durationSecs = int.Parse(Console.ReadLine());
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine("");
        Console.WriteLine("Well Done!");
        Console.WriteLine(" ");
        Console.WriteLine($"You have completed another {_durationSecs} seconds of the {_activityName}");

    }

    public string GetRandomItem(List<string> list)
    {
        Random rand = new Random();
        return list[rand.Next(list.Count)];
    }
    
    public void SetUp()
    {
        DisplayStartMessage();
        GetDuration();

        Console.Clear();
        Console.Write("Get ready..... ");
        _animation.LoadingAnimation(6);
        Console.WriteLine("");
    }
}
