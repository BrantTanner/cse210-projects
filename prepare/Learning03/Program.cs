using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(5);
        Fraction f3 = new Fraction(2, 3);

        // Display fraction as strings
        Console.WriteLine("Fraction 1: " + f1.GetFractionString());
        Console.WriteLine("Fraction 2: " + f2.GetFractionString());
        Console.WriteLine("Fration 3 " + f3.GetFractionString());

        // Convert them to decimal
        Console.WriteLine("Fraction 1 as decimal: " + f1.GetDecimalValue());
        Console.WriteLine("Fraction 2 as deciaml: " + f2.GetDecimalValue());
        Console.WriteLine("Fraction 3 as a decimal: " + f2.GetDecimalValue());

        // change num and denom using setters
        f3.SetTop(5);
        f3.SetBottom(8);

        Console.WriteLine("Updated Fracton 3: " + f3.GetFractionString());
        Console.WriteLine("Updated Fration 3 in decimal: " + f3.GetDecimalValue());
    }
}