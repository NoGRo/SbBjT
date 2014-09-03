using System.Collections.Generic;
using SbBjT.Bussines.PunishCore;

namespace SbBjT.Bussines.BlowJobCore
{
    public class BlowJobType
    {
 

        public bool RandomizePunishes { get; set; }
        public IPunish Punish { get; set; }
        public IBlowJobBehavior Behavior { get; set; }
        
        public Rest Rest { get; set; }
        
        public Duration Time { get; set; }
        public Duration Sucks { get; set; }
        public Duration Speed { get; set; }

        public BlowJobType()
        {
            Time= new Duration();
            Sucks = new Duration();
            Speed = new Duration();
            Punish =  new PunishMulti();
            Rest= new Rest();

        }


    }
}
