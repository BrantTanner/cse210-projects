public abstract class Circle
{
    // private member variables
    private int _x;
    private int _y;
    private int _size;
    private bool _infected;
    private float _dx;
    private float _dy;
    // precise position accumulators (allow fractional movement)
    private float _px;
    private float _py;

    private MovementController _controller;

    public Circle(int size, bool infected = false)
    {
        _size = size;
        _infected = infected;
        _x = 0;
        _y = 0;
        _px = 0;
        _py = 0;
        _dx = 0;
        _dy = 0;

        _controller = new MovementController();
    }

    public virtual void Update(int windowWidth, int windowHeight)
    {
        // update movement and bounce logic
        _controller.ApplyMovement(this);
        _controller.BounceOfWalls(this, windowWidth, windowHeight);
    }

    // movement style varies between infected and healthy
    public abstract void MovementBehavior(List<Circle> infectedNeighbors);

    // getters
    public int GetX() => _x;
    public int GetY() => _y;
    public int GetSize() => _size;
    public bool GetInfected() => _infected;
    public float GetDX() => _dx;
    public float GetDY() => _dy;

    // setters
    public void SetX(int x) => _x = x;
    public void SetY(int y) => _y = y;

    public void SetXPrecise(int x) { _x = x; _px = x; }
    public void SetYPrecise(int y) { _y = y; _py = y; }
    public void SetDX(float dx) => _dx = dx;
    public void SetDY(float dy) => _dy = dy;

    public void SetPosition(int x, int y)
    {
        _x = x;
        _y = y;
        _px = x;
        _py = y;
    }

    // Move by current velocity using float accumulators so small velocities accumulate
    public void MoveByVelocity()
    {
        _px += _dx;
        _py += _dy;

        _x = (int)_px;
        _y = (int)_py;
    }

    public void SetVelocity(float dx, float dy)
    {
        _dx = dx;
        _dy = dy;
    }

    public void SetInfected(bool infected) => _infected = infected;
}
