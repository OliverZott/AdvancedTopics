using System;

namespace Events
{
    internal class ShotFiredEventArgs : EventArgs
    {
        public DateTime TimeOfKill { get; set; }

        public ShotFiredEventArgs(DateTime time)
        {
            TimeOfKill = time;
        }

    }
}
