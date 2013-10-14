using System;
using SbBjT.Bussines.PunishCore;
using SbBjT.Bussines.VoiceCore;

namespace SbBjT.Bussines.BlowJobCore
{
    public class BlowJob
    {
        public BlowJobType BlowJobType { get; set; }
        public Master Master { get; set; }
        public Slave Slave { get; set; }
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

        private int SucksLeftToRest { get; set; }

        private PartName? Next;
        
        public BlowJob(Master master, Slave slave)
        {

            Master = master;

            BlowJobType = Master.Personality.BlowJobType;
            SucksLeft = BlowJobType.Sucks.Value;
            if (BlowJobType.Rest.Have)
                SucksLeftToRest = BlowJobType.Rest.SuckToRest.Value;
            blow =  new Blow
                        (
                            Master.Dick, 
                            BlowJobType.Speed.Value
                        );

            blow.SuckFail += OnBlowSuckFail;
            blow.SuckOk += OnBlowSuckOk;
            blow.SuckProcess += OnBlowSuckProcess;


        }
        public void AddSucks(int sucks)
        {
            SucksLeft += sucks;
        }
        public void NextDo(PartName partName)
        {
            Next = partName;
        }

        public void Start()
        {
            StartTime = DateTime.Now;
            blow.Do(PartName.Medium);
        }

        private void OnBlowSuckFail(object sender, EventArgs e)
        {
            Say say = Say.Bad;
               //punish
            Master.Talk(say);
        }
        private void NextSuck()
        {
            Say say = Say.Go;

            if (Next.HasValue)
            {
                if (Next.Value ==PartName.Deep)
                    say = Say.GoDeep;
                
                blow.Do(Next.Value);
                Next = null;
            }
            blow.Do(PartName.Medium);

            Master.Talk(say);
        }


        public event EventHandler SuckLeftChange;
        protected virtual void OnSuckLeftChange()
        {
            EventHandler handler = SuckLeftChange;
            if (handler != null) handler(this, EventArgs.Empty);
        }


        private void OnBlowSuckOk(object sender, EventArgs e)
        {

            SucksLeft--;
            SucksLeftToRest--;
            if (SucksLeft <= 0)
            {
                //end
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
            Master.Talk(Say.Plasure);
        }
    }
}
