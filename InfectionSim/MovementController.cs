public class MovementController
{


    public void ApplyMovement(Circle circle)
    {
        // Apply vertical and horizontal velocity to circles
        circle.setX(circle.GetX() + circle.GetDX());
        circle.setY(circle.GetY() + circle.GetDY());
    }

    public void BounceOfWalls(Circle circle, int windowWidth, int windowHeight)
    {   
        // Horizontal bounce
        if (circle.GetX() < 0 || circle.GetX() + circle.GetSize() > windowWidth)
        {
            circle.SetDX(-circle.GetDX());  // Reverse direction

            // Keep inside bounds
            if (circle.GetX() < 0)
                circle.SetX(0);
            else if (circle.GetX() + circle.GetSize() > windowWidth)
                circle.SetX(windowWidth - circle.GetSize());
        }

        // Vertical bounce
        if (circle.GetY() < 0 || circle.GetY() + circle.GetSize() > windowHeight)
        {
            circle.SetDY(-circle.GetDY());  // Reverse direction

            // Keep inside bounds
            if (circle.GetY() < 0)
                circle.SetY(0);
            else if (circle.GetY() + circle.GetSize() > windowHeight)
                circle.SetY(windowHeight - circle.GetSize());
        }
    }
}