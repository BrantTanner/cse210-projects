public class Circle
{
    // private member variables
    private int _x;
    private int _y;
    private int _size;
    private bool _infected;
    private float _dx;
    private float _dy;

    //
    MovementController _controller;
    CollisionDetector _detect;

    public Circle(int size, bool infected = false)
    {
        _size = size;
        _infected = infected;
        _x = 0;
        _y = 0;
        _dx = 0;
        _dy = 0;

        _controller = new MovementController();
        _detect = new CollisionDetector();
    }

    
    public virtual void Update(int windowWidth, int windowHeight)
    {
        // update movement and bounce logic
        _controller.ApplyMovement(this);
        _controller.BounceOfWalls(this);

        // detect collisions and infect circles
        _detect.CheckCollision(circle1, circle2);

        if (_detect.Collision && circle1.infected || circle2.infected)
        {
            circle1.infected = true;
            circle2.infected = true;

        }

    }

    // movement style vaires between infected and healthy
    public virtual void MovementBehavior();

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
    public void SetDX(int dx) => _dx = dx;
    public void SetDY(int dy) => _dy = dy;

    public void SetPosition(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public void SetVelocity(float dx, float dy)
    {
        _dx = dx;
        _dy = dy;
    }


}
