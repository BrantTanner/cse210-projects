public class Vehicle
{
    private string _make;
    private string _model;
    private int _year;

    public Vehicle(string make, string model, int year)
    {
        _make = make;
        _model = model;
        _year = year;
    }

    public void GetBaseDescription()
    {
        Console.WriteLine($"Vehicle with make: {_make}, model: {_model}, year: {_year}")
    }
        
}