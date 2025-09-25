using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = -1;
        int sumOfNumbers = 0;
        int largestNum = 0;

        Console.WriteLine("Please enter a list of numbers, type 0 when finished");

        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            numbers.Add(number);
        }


        foreach (int num in numbers)
        {
            sumOfNumbers += num;
        }

        // logic to calculate end results of list
        int lenOfLst = numbers.Count;
        int avgOfLst = sumOfNumbers / lenOfLst;

        foreach (int num in numbers)
        {
            if (num > largestNum)
            {
                largestNum = num;
            }
        }

        Console.WriteLine($"The sum is: {sumOfNumbers}");
        Console.WriteLine($"The average is: {avgOfLst}");
        Console.WriteLine($"The largest number: {largestNum}");
    }
}