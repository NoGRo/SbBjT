using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SbBjT.Bussines.PunishCore
{
    public class PunishMulti : IPunish
    {
        public bool Randomize { get; set; }
        public List<IPunish> Punishes { get; set; }
        public void Punish()
        {
            if (Randomize)
                Punishes[new Random().Next(0,Punishes.Count() - 1)].Punish();
            else
                Punishes.ForEach(x=> x.Punish());
        }
    }
}
    