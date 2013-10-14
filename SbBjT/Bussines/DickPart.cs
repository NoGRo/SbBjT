using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SbBjT.Bussines.ColorDetectorCore;
    

namespace SbBjT.Bussines
{
    public enum PartName
    {
        Out,
        Medium,
        Deep,
        RealyDeep,
        Ball
    }

    public class DickPart
    {
        public PartName Name { get; set; }
        public int FeelPercentI { get; set; }
        public ColorDetector ColorDetector { get; set; }

        public DickPart(PartName name)
        {
            Name = name;
        }
    }
    

}
