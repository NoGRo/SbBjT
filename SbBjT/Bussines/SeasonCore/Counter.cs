using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace SbBjT.Bussines.SeasonCore
{
    public class Counter
    {
        public TimeSpan Left { get; protected set; }
        public TimeSpan Past { get; private set; }
        public TimeSpan OriginalTime { get; private set; }
        public TimeSpan Max { get; set; }

        private bool _active;
        public bool Active
        {
            get {return _active; }
            set
            {
                TimerSecond.Enabled = value;
                _active = value;
            }
        }

        private Timer TimerSecond = new Timer();
        

        public Counter(CounterDuration duration)
        {

            Left = duration.Value;
            Max = duration.Max;
            OriginalTime = Left;

            TimerSecond.Interval = 1000;
            TimerSecond.Elapsed += TimerSecondElapsed;
        }

        public Counter(TimeSpan time)
        {

            Left = time;
            OriginalTime = Left;
            TimerSecond.Interval = 1000;
            TimerSecond.Elapsed += TimerSecondElapsed;
        }

       

        public virtual void Start()
        {

            TimerSecond.Stop();
            TimerSecond.Start();
            Active = true;
            OnStartCounter();
            if (Left.TotalSeconds <= 0)
            {
                End();
            }
        }

        public virtual void Pause()
        {
            Active = false;
        }

        public virtual void Resume()
        {
            Active = true;
        }

        public virtual void AddTime(TimeSpan time)
        {
            Left = Left.Add(time);

            if (Max.TotalSeconds > 0 && Left > Max) Left = Max;
        }

        public virtual void End()
        {
            Left = new TimeSpan();
            Active = false;
            OnEndCounter();
        }

        void TimerSecondElapsed(object sender, ElapsedEventArgs e)
        {
            if (Left.TotalSeconds > 0)
            {
                Left = Left.Add(-Util.OneSecond);
                Past = Past.Add(Util.OneSecond);
            }
            else
                End();
            if (Max.TotalSeconds > 0 && Past >= Max)
                End();
        }

        public event EventHandler StartCounter;

        protected virtual void OnStartCounter()
        {
            EventHandler handler = StartCounter;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event EventHandler EndCounter;

        protected virtual void OnEndCounter()
        {
            EventHandler handler = EndCounter;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
