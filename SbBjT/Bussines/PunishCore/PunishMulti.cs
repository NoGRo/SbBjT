using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SbBjT.Bussines.PunishCore
{
    public class PunishMulti : IPunish
    {
        public PunishMulti()
        {
        }

        public PunishMulti(IPunish[] punishes)
        {
            Punishes = punishes;
        }

        public bool Randomize { get; set; }
        public IPunish[] Punishes { get; set; }
        public void Punish()
        {
            if (Randomize)
                Punishes[new Random().Next(0,Punishes.Count() - 1)].Punish();
            else
                Punishes.ToList().ForEach(x=> x.Punish());
        }
    }
}
    