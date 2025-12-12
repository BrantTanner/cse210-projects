public class InfectedCircle : Circle
{
    private static readonly Random _rand = new Random();

    public InfectedCircle(int size) : base(size, true)
    {

    }

    // Infected movement: simple erratic jitter so infected circles keep moving
    public override void MovementBehavior(List<Circle> infectedNeighbors)
    {
        // small random jitter added to velocity
        float jitterX = ((float)_rand.NextDouble() - 0.5f) * 0.6f;
        float jitterY = ((float)_rand.NextDouble() - 0.5f) * 0.6f;

        // slightly increase base speed so infection spreads more
        float newDX = this.GetDX() + jitterX;
        float newDY = this.GetDY() + jitterY;

        // clamp speed to a reasonable range
        const float maxSpeed = 6f;
        if (MathF.Abs(newDX) > maxSpeed) newDX = MathF.Sign(newDX) * maxSpeed;
        if (MathF.Abs(newDY) > maxSpeed) newDY = MathF.Sign(newDY) * maxSpeed;

        this.SetVelocity(newDX, newDY);
    }
}