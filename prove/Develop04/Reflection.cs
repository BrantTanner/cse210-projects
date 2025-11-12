public class Reflection : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public Reflection(string activityName, string activityDescription, List<string> prompts, List<string> questions) : base(activityName, activityDescription)
    {
        _prompts = prompts;
        _questions = questions;
    }

    public void RunActivity()
    {
        SetUp();
    
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
       

        Console.WriteLine(GetRandomItem(_prompts));

        Console.WriteLine("Think Hard! When you have something in mind press Enter");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        CountDownTimer(5);
        Console.Clear();

        
        DateTime endTime = DateTime.Now.AddSeconds(_durationSecs);
        while (DateTime.Now < endTime)
        {
            Console.Write(GetRandomItem(_questions));
            _animation.LoadingAnimation(7);
            Console.WriteLine();
        }

        DisplayEndMessage();
    }
}