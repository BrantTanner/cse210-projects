public class Fraction
{
    private int _numerator;

    private int _denominator;

    public Fraction(int num)
    {
        _numerator = num;
        _denominator = 1;
    }
    public Fraction(int num, int den)
    {
        _numerator = num;
        if (den != 0)
        {
            _denominator = den;
        }
        else
        {
            
        }

           
           
    }

    public void Display()
    {
        // do something
        Console.WriteLine(_numerator / _denominator);
    }
}