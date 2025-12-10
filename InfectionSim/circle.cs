public class Circle
{
    // private member variables
    private int _x;
    private int _y;
    private int _size;
    private bool _infected;
    private float _dx;
    private float _dy;

    public Circle(int size, bool infected = false)
    {
        _size = size;
        _infected = infected;
        _x = 0;
        _y = 0;
        _dx = 0;
        _dy = 0;
    }

    // update movement and bounce logic
    public virtual void Update(int windowWidth, int windowHeight)
    {
        _x += (int)_dx;
        _y += (int)_dy;

        // bounce horizontally
        if (_x < 0 || _x + _size > windowWidth)
        {
            _dx = -_dx;
            if (_x < 0) _x = 0;
            if (_x + _size > windowWidth) _x = windowWidth - _size;
        }

        // bounce vertically
        if (_y < 0 || _y + _size > windowHeight)
        {
            _dy = -_dy;
            if (_y < 0) _y = 0;
            if (_y + _size > windowHeight) _y = windowHeight - _size;
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
