public class Listing : Activity
{
    private List<string> _listingPrompts;

    public Listing(string activityName, string activityDescription, int durationSecs, List<string> listingPrompts) : base(activityName, activityDescription, durationSecs)
    {
        _listingPrompts = listingPrompts;
    }

    public void RunActivity()
    {
        SetUp();

        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine(GetRandomItem(_listingPrompts));
        Console.Write("You may begin in: ");
        CountDownTimer(5);
        Console.WriteLine("");

        DateTime endTime = DateTime.Now.AddSeconds(_durationSecs);
        int responseCounter = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            responseCounter += 1;
        }
        Console.WriteLine($"You listed {responseCounter} items!");
        Console.WriteLine("\n");

        DisplayEndMessage();
    }
}