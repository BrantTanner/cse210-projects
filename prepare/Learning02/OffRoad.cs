using System.Dynamic;

public class OffRoad : Vehicle
{
    private bool _offRoadTires;
    private string _offRoadSuspension;

    public OffRoad(bool offRoadTires, string offRoadSuspension, string make, string model, int year) : base(make, model, year)
    {
        offRoadTires = _offRoadTires;
        offRoadSuspension = _offRoadSuspension;
    }

    public void GetOffRoadDescription()
    {
        Console.WriteLine($"with {_offRoadTires} and {_offRoadSuspension} suspension");
    }
}