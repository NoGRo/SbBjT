using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SbBjT.Bussines.ColorDetectorCore;

namespace SbBjT.Bussines
{
    public class FeelEventArgs : EventArgs
    {
        public DickPart DickPart { get; private set; }

        public FeelEventArgs(DickPart dickPart)
        {
            DickPart = dickPart;
        } // eo ctor

    } 

    public class Dick
    {
        public Dick()
        {
            if (Detector != null)
                Detector.Detection += DetectorOnDetection;
        }

        private Dictionary<PartName, bool> lastStates;
        private void DetectorOnDetection(object sender, EventArgs eventArgs)
        {

            if (lastStates == null )
                lastStates = DickParts.ToDictionary(x => x.Name, x => x.IsIn);

            
            foreach (DickPart dickPart in DickParts)
            {
                if (lastStates[dickPart.Name] != dickPart.IsIn)
                {
                    lastStates[dickPart.Name] = dickPart.IsIn;
                    if (dickPart.IsIn)
                        OnFeel(dickPart);
                }
            }
        }

        public Detector Detector { get; set; }
        public List<DickPart> DickParts { get; set; }


        public event EventHandler Feel;
        protected virtual void OnFeel(DickPart dickPart)
        {
            EventHandler handler = Feel;
            if (handler != null) handler(this, new FeelEventArgs(dickPart));
        }
        

    }

}
