using System;

namespace Gym.Infrastructure
{
    public static class TimespanExtensions
    {
        const double DaysInAYear = 365.25;

        public static double ToYears(this TimeSpan timeSpan)
        {
            return Math.Floor(timeSpan.TotalDays) / DaysInAYear;
        }
    }
}