using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SbBjT.Bussines.BlowJobCore;

namespace SbBjT.Bussines.PunishCore
{
    public class PunishSuckDo : IPunish
    {
        public PunishSuckDo(BlowJob blowJob, PartName partName)
        {
            BlowJob = blowJob;
            PartName = partName;
        }

        public BlowJob BlowJob { get; set; }
        public PartName PartName { get; set; }
        public void Punish()
        {
           BlowJob.NextDo(PartName);
        }
    }
}
