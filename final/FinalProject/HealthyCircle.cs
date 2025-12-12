public class HealthyCircle : Circle
{
    public HealthyCircle(int size): base(size, false)
    {
    }

    public override void MovementBehavior(List<Circle> infectedNeightbors)
    {
        float avoidX = 0;
        float avoidY = 0;

        foreach(var infected in infectedNeightbors)
        {
            // vector pointing away from the infected circle
            float _dx = this.GetX() - infected.GetX();
            float _dy = this.GetY() - infected.GetY();

            float distance = MathF.Sqrt(_dx * _dx + _dy * _dy);

            if (distance < 0.1f) distance = 0.1f; // avoid division by zero
            {
                // Normalize and accumulate avoidance force
                avoidX += _dx / distance;
                avoidY += _dy / distance;
            } 
        }

        // Apply avoidance
        this.SetVelocity(
            this.GetDX() + avoidX * 0.5f, // steering strength
            this.GetDY() + avoidY * 0.5f
        );
    }
}