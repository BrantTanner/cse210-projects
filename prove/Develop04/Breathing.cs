using System.Runtime.InteropServices;

public class Breathing : Activity
{

    public Breathing(string activityName, string activityDescription) : base(activityName, activityDescription)
    {
        
    }


    public void RunActivity()
    {
        SetUp();

        DateTime endTime = DateTime.Now.AddSeconds(_durationSecs);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            CountDownTimer(6);
            Console.Write("\n");
            
            Console.Write("Breathe out...");
            CountDownTimer(6);
            Console.Write("\n");
        }
        DisplayEndMessage();
    }

    
}
