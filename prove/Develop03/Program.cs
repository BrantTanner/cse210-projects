using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Develop03 World!");

        Job job1 = new Job();
        job1._company = "BYU-I";
        job1._title = "Programmer";
        job1._startDate = "1/1/2010";

        Job job2 = new Job();
        job2._company = "BYU provo";
        job2._title = "Programmer";
        job2._startDate = "1/1/2015";

        Resume resume1 = new Resume();
        resume1.AddJob(job1);
        resume1.AddJob(job2);
    }
}