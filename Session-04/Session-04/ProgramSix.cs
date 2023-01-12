using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_04
{
    internal class ProgramSix
    {
        public int SecondsToMinutes()
        {
            TimeSpan secs = TimeSpan.FromSeconds(1000000000);
            return (int)secs.TotalMinutes;
        }
        public int SecondsToHours()
        {
            TimeSpan secs = TimeSpan.FromSeconds(1000000000);
            return (int)secs.TotalHours;
        }
        public int SecondsToDays()
        {
            TimeSpan secs = TimeSpan.FromSeconds(1000000000);
            return (int)secs.TotalDays;
        }
        public int SecondsToYears()
        {
            TimeSpan secs = TimeSpan.FromSeconds(1000000000);
            return (int)(secs.TotalDays / 365);
        }
    }
}
