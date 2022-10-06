using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3
{
    public class ClockEventAgrs : EventArgs
    {
        public readonly int Second;
        public readonly int Minute;
        public readonly int Hour;
        public ClockEventAgrs(int second, int minute, int hour)
        {
            Second = second;
            Minute = minute;
            Hour = hour;

        }
    }
}