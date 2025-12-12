public class CircleGeneration
{
    private List<Circle> _circles;
    private Random _rand;
    private int _circleCount;
    private int _circleSize;
    private Size _clientSize;

    // To allow invalidate
    private Form _form;

    public CircleGeneration(List<Circle> circles, Random rand, int circleCount, int circleSize, Size clientSize, Form form)
    {
        _circles = circles;
        _rand = rand;
        _circleCount = circleCount;
        _circleSize = circleSize;
        _clientSize = clientSize;
        _form = form;

    }


    public void GenerateCircles()
        {
            _circles.Clear();

            // Generate list of circle objects (default is 100)
            for (int i = 0; i < _circleCount; i++)
            {
                Circle c;

                // first one is infected
                if (i == 0)
                {
                    c = new InfectedCircle(_circleSize);
                }
                else
                {
                    c = new HealthyCircle(_circleSize);
                }

                bool valid = false;

                // loop to calculate positon for each circle
                while (valid == false)
                {
                    // picks random location to place circle in the window. Makes sure all of the circle is of screen (- c.size)
                    c.SetPosition(_rand.Next(0, _clientSize.Width - c.GetSize()),
                                  _rand.Next(0, _clientSize.Height - c.GetSize()));

                    // assume the position is valid
                    valid = true;

                    // compare this circle with every other circle on screen
                    foreach (var other in _circles)
                    {
                        // finds the center X for new circle and existing circle
                        double dx = (c.GetX() + c.GetSize() / 2.0) - (other.GetX() + other.GetSize() / 2.0);
                        double dy = (c.GetY() + c.GetSize() / 2.0) - (other.GetY() + other.GetSize() / 2.0);
                        
                        // calculates distance between the two centers of the new circle and existing circle
                        double distance = Math.Sqrt(dx * dx + dy * dy);

                        // condition to check if circles overlap
                        if (distance < (c.GetSize() + other.GetSize()) / 2.0)
                        {
                            // position cannot be used and resets for a new position
                            valid = false;
                            break;
                        }
                    }
                }

                // Give each circle a random movement direction
                c.SetVelocity((float)(_rand.NextDouble() * 4 - 2), (float)(_rand.NextDouble() * 4 - 2)); // -2 to +2

                _circles.Add(c);
            }

            _form.Invalidate(); // redraw windows form (calls OnPaint)
        }

}