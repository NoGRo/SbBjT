using System;
using System.Drawing;
using System.Drawing.Imaging;
using Newtonsoft.Json;
namespace SbBjT.Bussines.ColorDetectorCore
{
    
    [Serializable]
    [JsonObject(MemberSerialization.OptOut)]
    public class ColorDetector 
    {
        public ColorDetector()
        {
        }


        public ColorDetector(Detector detector)
        {
            Detector = detector;
        }


        [JsonIgnore]
        public Detector Detector { get; set; }

        
        public Rectangle Area { get; set; }
        public Color Color { get; set; }
        public bool Detected { get; set; }
        public byte Acurassi { get; set; }


    }
}
