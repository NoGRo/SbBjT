using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SbBjT.Bussines.BlowJobCore;

namespace SbBjT.Bussines.PunishCore
{
    public class PunishSuckIncrease :IPunish
    {
        public PunishSuckIncrease(BlowJob blowJob, Duration duration)
        {
            BlowJob = blowJob;
            Duration = duration;
        }

        public BlowJob BlowJob { get; set; }
        public Duration Duration { get; set; }
        public void Punish()
        {
            BlowJob.AddSucks( Duration.Value);
        }
    }
}
