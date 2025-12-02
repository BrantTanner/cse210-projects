using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public partial class Form1 : Form
{
    List<Circle> circles = new List<Circle>();
    Random rand = new Random();

    int circleCount = 50;
    int circleSize = 20;

    public Form1()
    {
        InitializeComponent();
        this.DoubleBuffered = true; // smoother graphics
        GenerateCircles();
    }

    private void GenerateCircles()
    {
        circles.Clear();

        for (int i = 0; i < circleCount; i++)
        {
            Circle c = new Circle();
            c.Size = circleSize;

            bool valid = false;

            while (!valid)
            {
                c.X = rand.Next(0, ClientSize.Width - c.Size);
                c.Y = rand.Next(0, ClientSize.Height - c.Size);

                valid = true;

                foreach (var other in circles)
                {
                    double dx = (c.X + c.Size / 2) - (other.X + other.Size / 2);
                    double dy = (c.Y + c.Size / 2) - (other.Y + other.Size / 2);
                    double distance = Math.Sqrt(dx * dx + dy * dy);

                    if (distance < (c.Size + other.Size) / 2)
                    {
                        valid = false;
                        break;
                    }
                }
            }

            circles.Add(c);
        }

        circles[0].Infected = true; // first circle red
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        foreach (var circle in circles)
        {
            Brush b = circle.Infected ? Brushes.Red : Brushes.Green;

            e.Graphics.FillEllipse(
                b,
                circle.X,
                circle.Y,
                circle.Size,
                circle.Size
            );
        }
    }
}
