using System;
using System.Timers;

namespace SbBjT.Bussines.BlowJobCore
{
    public class Blow
    {
        public Timer TimerSpeed = new Timer();
        private PartName ToDo;

        public Blow(Dick dick, int speed)
        {
            Dick = dick;
            Speed = speed;
            TimerSpeed.Elapsed += TimerSpeedOnElapsed;
            TimerSpeed.Interval = Speed*1000;
            TimerSpeed.Stop();

            Dick.Feel += OnDickFeel;
        }

        public int Speed { get; set; }
        public Dick Dick { get; set; }

        private void TimerSpeedOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            OnSuckFail();
        }

        public void Do(PartName SuckState)
        {
            ToDo = SuckState;

            TimerSpeed.Stop();
            TimerSpeed.Start();
        }

        private void OnDickFeel(object sender, EventArgs args)
        {
            DickPart dickPart = ((FeelEventArgs) args).DickPart;
            if (dickPart.Name == ToDo)
            {
                ToDo = PartName.Out; // si hiso el suck no termina hasta que sale 
                if (dickPart.Name == PartName.Out) // si se esperaba el out y lo hiso termino bien en el blow
                {
                    TimerSpeed.Stop();
                    OnSuckOk();
                }
                else
                {
                    OnSuckProcess();
                }
                TimerSpeed.Stop();
                TimerSpeed.Start();
            }
        }


        public event EventHandler SuckFail;

        protected virtual void OnSuckFail()
        {
            EventHandler handler = SuckFail;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event EventHandler SuckProcess;

        protected virtual void OnSuckProcess()
        {
            EventHandler handler = SuckProcess;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event EventHandler SuckOk;

        protected virtual void OnSuckOk()
        {
            EventHandler handler = SuckOk;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}