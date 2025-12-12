using System.Net;

public class CollisionDetector
{
    double _distance;
    bool _collision;

    public void CheckCollision(Circle a, Circle b)
    {
        _distance = Math.Sqrt(a.GetDX() * b.GetDX() + a.GetDY() * b.GetDY());

        double radiusA = a.GetSize() / 2.0;
        double radiusB = b.GetSize() / 2.0;

        _collision = _distance < (radiusA + radiusB);
    }

    
}