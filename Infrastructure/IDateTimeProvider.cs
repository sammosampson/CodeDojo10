using System;

namespace Gym.Infrastructure
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrentDate();
    }
}