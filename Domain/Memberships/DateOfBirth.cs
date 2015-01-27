using System;
using SystemDot.Core;
using Gym.Infrastructure;

namespace Gym.Domain.Memberships
{
    public class DateOfBirth : Equatable<DateOfBirth>
    {
        public static DateOfBirth Parse(DateTime date)
        {
            return new DateOfBirth(date);
        }

        private readonly DateTime date;

        private DateOfBirth(DateTime date)
        {
            this.date = date;
        }

        public override bool Equals(DateOfBirth other)
        {
            return other.date == date;
        }

        public override int GetHashCode()
        {
            return date.GetHashCode();
        }

        public double CalculateAgeInYears(IDateTimeProvider dateTimeProvider)
        {
            return (dateTimeProvider.GetCurrentDate() - date).ToYears();
        }
    }
}