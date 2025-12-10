public class CircleGeneration
{
    private List<Circle> circles;
    private Random rand;
    private int _circleCount;
    private int _circleSize;
    private Size _clientSize;

    public CircleGeneration(List<Circle> circles, Random rand, int _circleCount, int _circleSize, Size _clientSize)
    {
        this.circles = circles;
        this.rand = rand;
        this.circleCount = _circleCount;
        this.circleSize = _circleSize;
        this.clientSize = _clientSize;

    }


    public void GenerateCircles()
        {
            circles.Clear();

            // Generate list of circle objects (default is 100)
            for (int i = 0; i < circleCount; i++)
            {
                Circle c;

                // first one is infected
                if (i == 0)
                {
                    c = new InfectedCircle(circleSize);
                }
                else
                {
                    c = new HealthyCircle(circleSize);
                }

                bool valid = false;

                // loop to calculate positon for each circle
                while (valid == false)
                {
                    // picks random location to place circle in the window. Makes sure all of the circle is of screen (- c.size)
                    c.SetPosition(rand.Next(0, ClientSize.Width - c.GetSize()),
                                  rand.Next(0, ClientSize.Height - c.GetSize()));

                    // assume the position is valid
                    valid = true;

                    // compare this circle with every other circle on screen
                    foreach (var other in circles)
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
                c.SetVelocity((float)(rand.NextDouble() * 4 - 2), (float)(rand.NextDouble() * 4 - 2)); // -2 to +2

                circles.Add(c);
            }

            Invalidate(); // redraw windows form (calls OnPaint)
        }

}