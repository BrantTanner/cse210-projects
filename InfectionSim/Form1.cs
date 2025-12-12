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
            CircleGeneration cG = new CircleGeneration(circles, rand, circleCount, circleSize, this.ClientSize);
            cG.GenerateCircles();
            Invalidate();
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
                
                // Infected circles = green, Healthy + red
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
