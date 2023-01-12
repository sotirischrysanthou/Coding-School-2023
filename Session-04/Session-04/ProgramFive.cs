using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_04
{
    internal class ProgramFive
    {
        public int SecondsToMinutes()
        {
            int seconds = 1000000000;
            int minutes = seconds / 60;
            return minutes;
        }
        public int SecondsToHours()
        {
            int seconds = 1000000000;
            int minutes = seconds / 60;
            int hours = minutes / 60;
            return hours;
        }
        public int SecondsToDays()
        {
            int seconds = 1000000000;
            int minutes = seconds / 60;
            int hours = minutes / 60;
            int days = hours / 24;
            return days;
        }
        public int SecondsToYears()
        {
            int seconds = 1000000000;
            int minutes = seconds / 60;
            int hours = minutes / 60;
            int days = hours / 24;
            int years = days / 365;
            return years;
        }

    }
}
