using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enums
{
    class Program
    {
        [Flags]
        enum DaysOfWeek
        {
            None = 0,
            Sunday = 1,
            Monday = 2,
            Tuesday = 4,
            Wednesday = 8,
            Thursday = 16,
            Friday = 32,
            Weekdays = Monday | Tuesday | Wednesday | Thursday | Friday,
            Saturday = 64,
            Weekend = Sunday | Saturday,
            All = Sunday | Monday | Tuesday | Wednesday | Thursday | Friday | Saturday
        }

        [Flags]
        enum DayType
        {
            Weekday = 1,
            Weekend = 2,
            Holiday = 4
        }
        static void Main(string[] args)
        {
            if (DaysOfWeek.Friday == DaysOfWeek.Weekend)
            {

            }
        }
    }
}
