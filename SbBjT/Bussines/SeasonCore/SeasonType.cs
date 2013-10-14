using System;
using SbBjT.Bussines.ReleaseCore;

namespace SbBjT.Bussines.SeasonCore
{
    public class SeasonType
    {
        public CounterDuration PreStart { get; set; }
        public CounterDuration Season { get; set; }
        public CounterDuration RelaseWait { get; set; }
        public IRelease Release { get; set; }
    }
}
