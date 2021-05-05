using System;

namespace Events
{
    internal static class Program
    {
        private static int _score;

        public static void Main(string[] args)
        {
            var shooter = new Shooter("Bob");

            // subscribe method to event (delegate chaining)
            shooter.ShotFired += AddScore;
            shooter.ShotFired += KilledEnemy;

            // invoke method that contains event
            shooter.OnShoot();

        }

        // methods which subscribes to event
        private static void AddScore(object sender, ShotFiredEventArgs e)
        {
            _score++;
        }
        private static void KilledEnemy(object sender, EventArgs e)
        {
            var tempSender = sender as Shooter;
            var tempE = e as ShotFiredEventArgs;

            if (tempSender is null)
            {
                return;
            }

            Console.WriteLine($"{tempSender.Name}: I hit an enemy at {tempE?.TimeOfKill}");         // how handling null? 
            Console.WriteLine($"My score now is: {_score}");
        }
    }


}
