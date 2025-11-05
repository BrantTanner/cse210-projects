using System;

class Program
{
    static void Main(string[] args)
    {
        Vehicle vehicle1 = new Vehicle("Honda", "Civic", 2014);
        vehicle1.GetBaseDescription();

        Motorcycle jimmy = new Motorcycle("seat", "2-stroke", false, "Harley", "Davison", 1999)
        jimmy.GetDescription();
    }
}