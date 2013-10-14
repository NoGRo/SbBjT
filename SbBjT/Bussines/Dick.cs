using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public List<DickPart> DickParts { get; set; }

        public void FeelWhat(DickPart dickPart)
        {
            OnFeel(dickPart);
        }

        public event EventHandler Feel;
        protected virtual void OnFeel(DickPart dickPart)
        {
            EventHandler handler = Feel;
            if (handler != null) handler(this, new FeelEventArgs(dickPart));
        }
        

    }

}
