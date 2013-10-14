using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SbBjT.Bussines.BlowJobCore;
using SbBjT.Bussines.PunishCore;
using SbBjT.Bussines.VoiceCore;

namespace SbBjT.Bussines
{

    public class Master
    {
        public Dick Dick { get; set; }
        public bool Sex { get; set; }
        public Voice Voice { get; set; }
        public Personality Personality { get; set; }
     
        public BlowJob BlowJob { get; set; }
        

        public BlowJob GetBlowJob()
        {

            BlowJobType blowJobType = Personality.BlowJobType;
            blowJobType.Rest.Have = false;
            blowJobType.Speed.Value = 3;
            //blowJobType.Sucks.Value = 20;

            BlowJob blowJob = new BlowJob(this,new Slave());
            // Punishes.Add(new PunishSuckIncrease(this, new Duration(2)));

            blowJob.Start();
            return blowJob;

        }  
        public void Talk(Say say)
        {
            Voice.Talk(say);
        }

    }

}
