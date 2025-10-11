public class Resume
{
    public List<Job> _jobs = new List<Job>();
    public string _company;
    public string _name;


    public void Display()
    {
        //do something
        Console.WriteLine($"Name: {_name}");

        foreach(Job job in _jobs)
        {
            job.Display();
        }
    }

    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }
}