using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SbBjT.Bussines.ColorDetectorCore;
using SbBjT.Bussines.ExtendedMethod;


namespace SbBjT.Bussines
{
    public enum PartName
    {
        [StringValue("Tip")] 
        Tip,
         [StringValue("Medium")] 
        Medium,
         [StringValue("Deep")] 
        Deep,
         [StringValue("RealyDeep")] 
        RealyDeep,
         [StringValue("Ball")] 
        Ball
    }

    public class DickPart
    {
        public PartName Name { get; set; }
        public string strName
        {
            get { return Name.ToString(); }

        }
        public bool IsIn    
        {
            get { return !ColorDetector.Detected; }
        }
        public ColorDetector ColorDetector { get; set; }

        public DickPart(PartName name)
        {
            Name = name;
        }
        public DickPart(PartName name,ColorDetector colorDetector )
        {
            ColorDetector = colorDetector;
            Name = name;
        }
    }
    

}
