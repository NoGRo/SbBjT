using System;
using System.Collections.Generic;
using System.Timers;
using SbBjT.Bussines.ReleaseCore;

namespace SbBjT.Bussines.SeasonCore
{
    public enum SeasonState
    {
            Stop,
            PreStartWaiting,
            Started,
            ReleaseWaiting,
            Ended

    }
    public class Season : Counter
    {
        
        public Counter PreStart { get; set; }
        public Counter RelaseWait { get; set; }
        public Counter CurrentSeason { get; set; }        
        public SeasonState State { get; set; }

        public IRelease Release { get; set; }
        
        public Master Master { get; set; }
        public List<Slave> Slaves { get; set; }

        public Season(SeasonType seasonType)
            : base(seasonType.Season)
        {
            PreStart = new Counter(seasonType.PreStart);
            PreStart.EndCounter += PreStartOnEndCounter;
            CurrentSeason = new Counter(seasonType.Season);
            CurrentSeason.EndCounter += SeasonTimeOnEndCounter;
            RelaseWait = new Counter(seasonType.RelaseWait);
            RelaseWait.EndCounter += RelaseWaitOnEndCounter;
            Release = seasonType.Release;
        }

        public override void Start()
        {
            this.Left = PreStart.Left + CurrentSeason.Left + RelaseWait.Left;


            State = SeasonState.PreStartWaiting;
            PreStart.Start();

        }

        public override void Pause()
        {
            switch (State)
            {
                case SeasonState.Stop:
                    break;
                case SeasonState.PreStartWaiting:
                    PreStart.Pause();
                    break;
                case SeasonState.Started:
                    CurrentSeason.Pause();
                    break;
                case SeasonState.ReleaseWaiting:
                    RelaseWait.Pause();
                    break;
                case SeasonState.Ended:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public override void Resume()
        {
            switch (State)
            {
                case SeasonState.Stop:
                    break;
                case SeasonState.PreStartWaiting:
                    PreStart.Resume();
                    break;
                case SeasonState.Started:
                    CurrentSeason.Resume();
                    break;
                case SeasonState.ReleaseWaiting:
                    RelaseWait.Resume();
                    break;
                case SeasonState.Ended:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void End()
        {
            PreStart= null;
            CurrentSeason = null;
            RelaseWait = null;
            Release.Release();
        }

        private void RelaseWaitOnEndCounter(object sender, EventArgs eventArgs)
        {
            State = SeasonState.Ended;
        }

        private void SeasonTimeOnEndCounter(object sender, EventArgs eventArgs)
        {
            State = SeasonState.ReleaseWaiting;
            RelaseWait.Start();
        }

        private void PreStartOnEndCounter(object sender, EventArgs eventArgs)
        {
            State = SeasonState.Started;
            CurrentSeason.Start();
        }

        





    }


}

