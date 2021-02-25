using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlanAuctions.Helpers
{
    public class TimeLength
    {
        public static TimeSpan TenSecondsWait = TimeSpan.FromSeconds(10);
        public static TimeSpan TwentySecondsWait = TimeSpan.FromSeconds(20);
        public static TimeSpan FourtySecondsWait = TimeSpan.FromSeconds(40);
        public static TimeSpan SixtySecondsWait = TimeSpan.FromSeconds(60);
        public static TimeSpan TwoMinutesWait = TimeSpan.FromSeconds(120);
    }
}
