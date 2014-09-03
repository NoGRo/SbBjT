using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SbBjT.Bussines.BlowJobCore
{
    public interface IBlowJobBehavior 
    {
        BlowJob BlowJob { get; set; }
        PartName NextDo();
    }
    public class Multi : IBlowJobBehavior
    {
        private IBlowJobBehavior[] behaviors;
        public Multi(IBlowJobBehavior[] muls)
        {
            behaviors = muls;
        }

        public BlowJob BlowJob { get; set; }
        public PartName NextDo()
        {
            
           PartName max = PartName.Medium;

            foreach (var blowJobBehavior in behaviors)
            {
                PartName b = blowJobBehavior.NextDo();
                if (b > max)
                    max = b;

            }
            return max;
        }
    }

    public class Every : IBlowJobBehavior
    {
        public Every(){}
        public Every(int Do, int In, PartName partName)
        {
            this.Do = Do;
            this.In = In;
            PartName = partName;

        }
        public int Do { get; set; }
        public int In { get; set; }
        private int Count;

        public PartName PartName { get; set; }

        public BlowJob BlowJob { get; set; }
        public PartName NextDo()
        {
            Count++;
            if (Count == In) Count = 0;
            if (Count >= (In - Do) )
            {
                return PartName;
            }
            return PartName.Medium;
        }
    }
    public class EveryRandom : IBlowJobBehavior
    {
        public EveryRandom() {}

        public EveryRandom(int Do, int In, PartName partName)
        {
            this.Do = Do;
            this.In = In;
            PartName = partName;

        }
        public int Do { get; set; }
        public int In { get; set; }
        public PartName PartName { get; set; }
        
        public BlowJob BlowJob { get; set; }
        public PartName NextDo()
        {
            int value = new Random().Next(1, In);
            if (value <= Do)
                return PartName;

            return PartName.Medium;
        }
    }
    public class AndLast : IBlowJobBehavior
    {
        public AndLast(){}

        public AndLast(IBlowJobBehavior behavior, int last, PartName partName)
        {
            this.Behavior = behavior;
            this.Last = last;
            PartName = partName;

        }
        public IBlowJobBehavior Behavior { get; set; }
        public int Last { get; set; }
        public PartName PartName { get; set; }
        private BlowJob _blowJob;
        public BlowJob BlowJob { 
            get { return _blowJob; }
            set
            {
                _blowJob = value;
                if (Behavior != null) Behavior.BlowJob = value;
            } 
        }

        public PartName NextDo()
        {
            return BlowJob.SucksLeft <= Last ?
                            PartName :
                            (Behavior == null ?
                                PartName.Medium : 
                                Behavior.NextDo());
        }
    }
}
