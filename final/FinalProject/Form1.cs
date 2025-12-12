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
            
            // Generate circles on screen
            CircleGeneration cG = new CircleGeneration(circles, rand, circleCount, circleSize, this.ClientSize, this);
            cG.GenerateCircles();
            Invalidate();
        }

        

        private void UpdateSim(object? sender, EventArgs e)
        {
            // 1. Update movement of every circle
            foreach (var c in circles)
            {
                c.Update(ClientSize.Width, ClientSize.Height);
            }

            // 2. Collision detection between all circle pairs
            CollisionDetector detector = new CollisionDetector();

            for (int i = 0; i < circles.Count; i++)
            {
                for (int j = i + 1; j < circles.Count; j++)
                {
                    var c1 = circles[i];
                    var c2 = circles[j];

                    detector.CheckCollision(c1, c2);

                    if (detector.Collision)
                    {
                        // spread infection
                        if (c1.GetInfected() || c2.GetInfected())
                        {
                            c1.SetInfected(true);
                            c2.SetInfected(true);
                        }
                    }
                }
            }

            // 3. Redraw screen
            Invalidate();
        }


        // method that runs every time the form is redrawn
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            float neighborRadius = 25f;
            float neighborRadiusSq = neighborRadius * neighborRadius;

            foreach (var circle in circles)
            {
                // Only healthy circles should avoid infected neighbors.
                if (!circle.GetInfected())
                {
                    var infectedNearby = new List<Circle>();
                    foreach (var other in circles)
                    {
                        if (other == circle) continue;

                        float dx = circle.GetX() - other.GetX();
                        float dy = circle.GetY() - other.GetY();
                        float distSq = dx * dx + dy * dy;

                        if (distSq <= neighborRadiusSq && other.GetInfected())
                            infectedNearby.Add(other);
                    }

                    // let healthy circle react to nearby infected circles
                    circle.MovementBehavior(infectedNearby);
                }
                else
                {
                    // infected circles use their own movement behavior (no avoidance list)
                    circle.MovementBehavior(new List<Circle>());
                }

                // choose brush by infection state and draw 
                Brush brush;
                if (circle.GetInfected())
                    brush = Brushes.Green;
                else
                    brush = Brushes.Red;

                e.Graphics.FillEllipse(
                    brush,
                    circle.GetX(),
                    circle.GetY(),
                    circle.GetSize(),
                    circle.GetSize()
                );
            }
        }
    }
}

