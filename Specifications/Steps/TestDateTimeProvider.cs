using System;
using Gym.Infrastructure;

namespace Gym.Specifications.Steps
{
    public class TestDateTimeProvider : IDateTimeProvider
    {
        DateTime date = DateTime.Now;

        public DateTime GetCurrentDate()
        {
            return date;
        }

        public void SetDate(DateTime toSet)
        {
            date = toSet;
        }
    }
}