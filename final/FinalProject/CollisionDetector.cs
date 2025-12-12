using System.Net;

public class CollisionDetector
{
    double _distance;
    bool _collision;

    public void CheckCollision(Circle a, Circle b)
    {
        // distance between centers
        double dx = a.GetX() - b.GetX();
        double dy = a.GetY() - b.GetY();

        _distance = Math.Sqrt(dx * dx + dy * dy);

        double radiusA = a.GetSize() / 2.0;
        double radiusB = b.GetSize() / 2.0;

        _collision = _distance <= (radiusA + radiusB);

    }

        public bool Collision => _collision;
}