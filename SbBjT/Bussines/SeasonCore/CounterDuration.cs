using System;

namespace SbBjT.Bussines.SeasonCore
{
    public class CounterDuration
    {
        public CounterDuration()
        {
        }

        public CounterDuration(TimeSpan value)
        {
            Value = value;
        }

        public CounterDuration(TimeSpan min, TimeSpan max)
        {
            Max = max;
            Min = min;
            Randomize = true;
        }

        public TimeSpan Value { get; set; }
        public TimeSpan Min { get; set; }
        public TimeSpan Max { get; set; }
        public bool Randomize { get; set; }
    }
}