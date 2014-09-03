using System;
using System.Collections.Generic;
using SbBjT.Bussines.PunishCore;
using SbBjT.Bussines.VoiceCore;

namespace SbBjT.Bussines.BlowJobCore
{
    public class BlowJob
    {
        public BlowJobType BlowJobType { get; set; }
        public Master Master { get; set; }
        public Slave Slave { get; set; }
        public IPunish Punish { get; set; }
        private Blow blow;
        private DateTime StartTime;
        private int _sucksLeft;
        public int SucksLeft   
        {
            get { return _sucksLeft; }
            private set 
            {
                _sucksLeft = value;
                if (BlowJobType.Sucks.Max > 0 && _sucksLeft > BlowJobType.Sucks.Max)
                    _sucksLeft = BlowJobType.Sucks.Max;

                    
                OnSuckLeftChange();
            }
        }

        public List<PartName> History { get; set; }
        private int SucksLeftToRest { get; set; }
        private PartName? Next;

        public BlowJob(Master master, Slave slave)
        {

            Punish = new PunishMulti();
            Master = master;
            History = new List<PartName>();
            BlowJobType = Master.Personality.BlowJobType;
            SucksLeft = BlowJobType.Sucks.Value;
            if (BlowJobType.Rest.Have)
                SucksLeftToRest = BlowJobType.Rest.SuckToRest.Value;

            if (BlowJobType.Behavior != null)
                BlowJobType.Behavior.BlowJob = this;
            Punish = BlowJobType.Punish;
        }


    

        public void AddSucks(int sucks)
        {
            SucksLeft += sucks;
        }
        public void NextDo(PartName partName)
        {
            Next = partName;
        }
        private void NextSuck()
        {

            if (!Next.HasValue)
            {
                Next = BlowJobType.Behavior == null ?
                            PartName.Medium :
                            BlowJobType.Behavior.NextDo();
            }

            switch (Next.Value)
            {
                //case PartName.Tip:
                //    break;
                //case PartName.Ball:
                //    break;
                case PartName.Medium:
                    Master.Talk(Say.Go);
                    break;
                case PartName.Deep:
                    Master.Talk(Say.GoDeep);
                    break;
                case PartName.RealyDeep:
                    Master.Talk(Say.GoRealyDeep);
                    break;
                default:
                    Master.Talk(Say.Go);
                    break;
                    
            }
            blow.Do(Next.Value);
            
            Next = null;

        }

        public void Start()
        {
            blow = new Blow
                      (
                          Master.Dick,
                          BlowJobType.Speed.Value
                      );
            blow.SuckFail += OnBlowSuckFail;
            blow.SuckOk += OnBlowSuckOk;
            blow.SuckProcess += OnBlowSuckProcess;

            Master.Talk(Say.Go);
            StartTime = DateTime.Now;
            blow.Do(PartName.Medium);
        }
        public void Stop()
        {
            Master.Talk(Say.End);
            blow = null;
        }

        public event EventHandler SuckLeftChange;
        protected virtual void OnSuckLeftChange()
        {
            EventHandler handler = SuckLeftChange;
            if (handler != null) handler(this, EventArgs.Empty);
        }
        
        private void OnBlowSuckFail(object sender, EventArgs e)
        {
            if (blow == null) return;
            Say say = Say.Bad;
            Punish.Punish();
            Master.Talk(say);
            
        }
        private void OnBlowSuckOk(object sender, EventArgs e)
        {
            if (blow == null) return;
            SucksLeft--;
            SucksLeftToRest--;
            History.Add(blow.ToDoPart);
            if (SucksLeft <= 0)
            {
                Stop();
                return;
            }
            if (BlowJobType.Rest.Have)
            {
                SucksLeftToRest--;
                if (SucksLeftToRest <= 0)
                {
                    //rest
                    SucksLeftToRest = BlowJobType.Rest.SuckToRest.Value;
                }
            }
            NextSuck();
        }
        private void OnBlowSuckProcess(object sender, EventArgs e)
        {
            if (blow == null) return;
            Master.Talk(Say.Plasure);
        }
    }
}
