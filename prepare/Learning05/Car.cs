public class Car : Vehicle
{
    private int _trunk;
    private bool toeHitch;
    private string _fuelType;

    public Car(int trunk, bool toehitch, string _fuelType, string make, string model, int year) : base(make, model, year)
    {
        
    }
}