public class Vehicle
{
    private string _make;
    private string _model;
    private int _year;

    public Vehicle(string make, string model, int year)
    {
        make = _make;
        model = _model;
        year = _year;
    } 
    
    public void GetBaseDescription()
    {
        Console.WriteLine($"This vehicle is a {_year} {_make} {_model}");
    }
}