using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace InfectionSim

{
    
    public partial class Form1 : Form
    {
        // member variables
        List<Circle> circles = new List<Circle>();
        Random rand = new Random();

        int circleCount = 100;
        int circleSize = 20;
        
        private SimulationTimer simTimer;


        public Form1() // constructor
        {
            InitializeComponent();
            this.DoubleBuffered = true; // smoother graphics
            
            // initialize timer
            simTimer = new SimulationTimer(16); // 60 FPS
            simTimer.Tick += UpdateSim; // subscribe to tick event
            simTimer.Start();
            
            GenerateCircles();
        }

        private void GenerateCircles()
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

        private void UpdateSim(object? sender, EventArgs e)
        {
            foreach (var c in circles)
            {
                c.Update(ClientSize.Width, ClientSize.Height);
            }

            Invalidate();
        }

        // method that runs evertime the form is redrawn
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // loop through list of circle objects
            foreach (var circle in circles)
            {
                Brush b;
                
                // Infected circles are red and the others are green
                if(circle.GetInfected()){
                    b = Brushes.Red;
                }
                else
                {
                    b = Brushes.Green;
                }

                e.Graphics.FillEllipse(
                    b, // brush color
                    circle.GetX(), // X position
                    circle.GetY(), // Y position
                    circle.GetSize(), // Width
                    circle.GetSize() // Height (width and height are the same value to make a circle)
                );
            }
        }
    }
}
