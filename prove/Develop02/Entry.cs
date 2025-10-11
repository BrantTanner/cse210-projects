using System.Net;

public class Entry
{
    public string _prompt;
    public string _response;
    public string _date;

    public List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    
    public string Prompt()
    {
        // Create random object
        Random random = new Random();

        // Pick random index
        int index = random.Next(_prompts.Count);

        // Get random string
        string randomPrompt = _prompts[index];

        Console.WriteLine(randomPrompt);
        string userResponse = Console.ReadLine();

        return userResponse;
    }
}


