using System.Globalization;
using System.Runtime.InteropServices;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNum)
    {
        _top = wholeNum;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public int GetTop()
    {
       int numerator = _top;

        return numerator;
    }
    public void SetTop(int numerator)
    {
        _top = numerator;
    }
    public int GetBottom()
    {
        int denominator = _bottom;

        return denominator;
    }
    public void SetBottom(int denominator)
    {
        _bottom = denominator;
    }

    public string GetFractionString()
    {
        // add top and bottom together to make a string
        string fractionString = $"{_top}/{_bottom}";

        return fractionString;
    }

    public double GetDecimalValue()
    {
        

        return (double)_top / _bottom;
    }





}