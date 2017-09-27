using System;
using System.Diagnostics;
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
            for (int i = 0; i < 10; i++)
            {
                TimeStringConcatenation();
                Console.WriteLine("");
            }

            Console.Read();
        }

        private static void TimeStringConcatenation()
        {
            Stopwatch sw1 = new Stopwatch();

            sw1.Start();

            for (int i = 0; i < 100000; i++)
            {
                var s = string.Format("Today is: {0}", DayOfWeek.Friday);
            }
            sw1.Stop();
            Console.WriteLine(sw1.Elapsed);
            sw1.Restart();

            for (int i = 0; i < 100000; i++)
            {
                var s = "Today is: {0}";
                s += DayOfWeek.Friday;
            }

            sw1.Stop();
            Console.WriteLine(sw1.Elapsed);
            sw1.Restart();

            for (int i = 0; i < 100000; i++)
            {
                var s = $"Today is: {DaysOfWeek.Friday}";
            }

            sw1.Stop();
            Console.WriteLine(sw1.Elapsed);
            sw1.Restart();

            for (int i = 0; i < 100000; i++)
            {
                StringBuilder s = new StringBuilder();
                s.AppendFormat("Today is: {0}", DayOfWeek.Friday);
                var st = s.ToString();
            }

            sw1.Stop();
            Console.WriteLine(sw1.Elapsed);
            sw1.Reset();
        }
    }
}
