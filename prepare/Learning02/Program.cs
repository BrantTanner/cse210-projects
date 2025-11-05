using System;

class Program
{
    static void Main(string[] args)
    {
        Vehicle baseVehicle = new Vehicle("Honda", "Civic", 2000);
        baseVehicle.GetBaseDescription();

        OffRoad offRoadVehicle = new OffRoad(true, "King Shocks", "Ford", "Ranger", 1998);
        offRoadVehicle.GetBaseDescription();
        offRoadVehicle.GetOffRoadDescription();
    }
}