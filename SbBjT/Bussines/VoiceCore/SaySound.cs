using System;
using System.Collections.Generic;
using System.Linq;
using SbBjT.Bussines.ExtendedMethod;

namespace SbBjT.Bussines.VoiceCore
{
        public enum Say
    {
        [StringValue("GoDeep")] 
        GoDeep,
        [StringValue("Go")]
        Go,
        [StringValue("GoodSlave")]
        GoodSlave,
        [StringValue("FilPlasure")]
        Plasure,
        [StringValue("Bad")]
        Bad,
        [StringValue("VeryBad")]
        VeryBad,
        [StringValue("Punish")]
        Punish,
        [StringValue("Start")]
        Start,
        [StringValue("End")]
        End
    }
    public class SaySound
    {
        public Say Say { get; set; }
        public bool Have { get; set; }
        private IDictionary<int, string> Sounds;

        public SaySound(Say say)
        {
            Say = say;
            Sounds =  new Dictionary<int, string>();
        }

        public void AddSound(string Path)
        {
            Have = true;
            Sounds.Add(Sounds.Count,Path);
        }

        public string GetRandom()
        {
            Random randNum = new Random();

            return Sounds[randNum.Next(0, Sounds.Count()-1)];
        }
    }
}
