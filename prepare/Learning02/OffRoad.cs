using System.Dynamic;

public class OffRoad : Vehicle
{
    private bool _offRoadTires;
    private string _offRoadSuspension;

    public OffRoad(bool offRoadTires, string offRoadSuspension, string make, string model, int year) : base(make, model, year)
    {
        _offRoadTires = offRoadTires;
        _offRoadSuspension = offRoadSuspension;
    }

    public void GetOffRoadDescription()
    {
        if (_offRoadTires == true)
             Console.Write($"with offroad tires and  {_offRoadSuspension} suspension");
        else
        {
             Console.Write($"with {_offRoadSuspension} suspension");
        }
    }
}