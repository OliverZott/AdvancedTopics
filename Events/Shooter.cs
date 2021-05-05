using System;
using System.Threading;

namespace Events
{
    /// <summary>
    /// Publisher
    /// A Class which will do some job and on completion of job an event will be fired which triggers an action
    /// </summary>
    internal class Shooter
    {
        private readonly Random _rng = new();

        //public delegate void ShootEventHandler(object sender, ShotFiredEventArgs e);

        public event EventHandler<ShotFiredEventArgs> ShotFired;

        public string Name { get; set; }

        public Shooter()
        {
        }
        public Shooter(string name) => this.Name = name;

        public void OnShoot()
        {
            while (true)
            {
                if (_rng.Next(0, 100) % 2 == 0)
                {
                    ShotFired?.Invoke(this, new ShotFiredEventArgs(DateTime.Now));   // Raise event by this (Shooter instance)
                }
                else
                {
                    Console.WriteLine("I missed.");
                }

                Thread.Sleep(500);
            }
        }
    }
}