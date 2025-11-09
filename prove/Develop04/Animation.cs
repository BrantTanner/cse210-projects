public class Animation
{
    public List<string> _animationSymbols;

    public Animation()
    {
        _animationSymbols = new List<string> { "|", "/", "-", "\\", "|", "/", "-", "\\" };;
    }
    public void LoadingAnimation(int duration)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = _animationSymbols[i];
            Console.Write(s);
            Thread.Sleep(450);
            Console.Write("\b \b");

            i++;

            if (i >= _animationSymbols.Count)
            {
                i = 0;
            }
        }
    }
}