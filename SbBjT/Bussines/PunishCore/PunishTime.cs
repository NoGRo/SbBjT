using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SbBjT.Bussines.SeasonCore;

namespace SbBjT.Bussines.PunishCore
{
    public class PunishTime : IPunish
    {
        public Counter Counter { get; set; }
        public CounterDuration Duration { get; set; }
        public void Punish()
        {
            Counter.AddTime(Duration.Value);
        }
    }
}
