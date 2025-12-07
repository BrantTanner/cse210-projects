using System;
using System.Windows.Forms;

namespace InfectionSim
{
    public class SimulationTimer
    {
        private System.Windows.Forms.Timer timer;
        
        public event EventHandler? Tick;

        public SimulationTimer(int intervalsMs = 16)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = intervalsMs;
            timer.Tick += (s, e) => Tick?.Invoke(s, e);
        }

        public void Start() => timer.Start();
        public void Stop() => timer.Stop();
    }
}