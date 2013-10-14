using System;

namespace SbBjT.Bussines
{
    public class Duration
    {
        

        public Duration()
        {
        }

        public Duration(int value)
        {
            Value = value;
        }


        public Duration(int min, int max)
        {
            Max = max;
            Min = min;
            Randomize = true;
        }

        private int? _value;
        public int Value
        {
            get
            {
                if (Randomize && !_value.HasValue)
                    _value = new Random().Next(Min, Max);
                
                 if (_value == null)
                     _value = 0;


                return _value.Value;
            }
            set { _value = value; }
        }

        public int Min { get; set; }
        public int Max { get; set; }
        public bool Randomize { get; set; }
    }
}