using System;
using System.Threading;

namespace Events
{
    internal static class Program
    {
        static int score = 0;

        public static void Main(string[] args)
        {
            var shooter = new Shooter();

            // subscribe method to event (delegate chaining)
            shooter.ShotFired += KilledEnemy;
            shooter.ShotFired += AddScore;

            // invoke method that contains event
            shooter.OnShoot();
        }

        // method which subscribes to event
        private static void KilledEnemy(object sender, EventArgs e)
        {
            Console.WriteLine("I hit an enemy.");
            Console.WriteLine($"My score now is: {score}");
        }

        private static void AddScore(object sender, EventArgs e)
        {
            score++;
        }
    }


    internal class Shooter
    {
        private readonly Random _rng = new();

        public delegate void KillingHandler(object sender, EventArgs e);

        public event KillingHandler ShotFired;

        public void OnShoot()
        {
            while (true)
            {
                if (_rng.Next(0, 100) % 2 == 0)
                {
                    ShotFired?.Invoke(this, EventArgs.Empty);
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
