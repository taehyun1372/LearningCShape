using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor_Client.Core
{
    public class AnalogSensor : AnalogBase
    {
        private System.Timers.Timer _timer = new System.Timers.Timer();
        private int _stepCounter = 0;
        public int StepCounter
        {
            get
            {
                return _stepCounter;
            }
            set
            {
                _stepCounter = value;
            }
        }
        public AnalogSensor()
        {
            //Set the initial Values
            CurrentValue = NextDouble(MinRange, MaxRange);
            PrevTarget = CurrentValue;
            NextTarget = NextDouble(MinRange, MaxRange);
            _stepCounter = 1;
            _timer.Interval = 1000;
            _timer.Elapsed += (s, e) => NextStep();
            _timer.Start();
        }

        private double NextDouble(double min, double max)
        {
            lock (_lock)
            {
                return min + _rand.NextDouble() * (max - min);
            }
        }

        private double _nextTarget;
        public double NextTarget
        {
            get
            {
                return _nextTarget;
            }
            set
            {
                _nextTarget = value;
            }
        }

        private double _currentValue;
        public double CurrentValue
        {
            get
            {
                return _currentValue;
            }
            set
            {
                _currentValue = value;
            }
        }

        private double _prevTarget;
        public double PrevTarget
        {
            get
            {
                return _prevTarget;
            }
            set
            {
                _prevTarget = value;
            }
        }

        private double StepIncrease
        {
            get
            {
                return (NextTarget - PrevTarget) / LongTermInterval;
            }
        }

        public void NextStep()
        {
            StepCounter++;

            //Long term target update 
            if (_stepCounter % LongTermInterval == 0)
            {
                CurrentValue = NextTarget;
                PrevTarget = NextTarget;
                NextTarget = NextDouble(MinRange, MaxRange);

                CurrentValue += GenerateNoise(StepIncrease);
            }


            CurrentValue += StepIncrease;
            CurrentValue += GenerateNoise(StepIncrease);
        }

        public double GenerateNoise(double stepIncrease)
        {
            return NextDouble(-1 * (Math.Abs(stepIncrease) * MaxNoise), Math.Abs(stepIncrease) * MaxNoise);
        }
    }
    public class AnalogBase
    {
        public static Random _rand = new Random();
        public object _lock = new object();

        private int _longTermInterval = 10; //10 sec 
        public int LongTermInterval
        {
            get { return _longTermInterval; }
            set { _longTermInterval = value; }
        }
        private int _unitTime = 1; //1 sec 
        public int UintTime
        {
            get { return _unitTime; }
            set { _unitTime = value; }
        }
        private double _minRange = 0;
        public double MinRange
        {
            get { return _minRange; }
            set { _minRange = value; }
        }
        private double _maxRange = 100;
        public double MaxRange
        {
            get { return _maxRange; }
            set { _maxRange = value; }
        }

        private double _maxNoise = 0.3; //30 Percent of step increase
        public double MaxNoise
        {
            get { return _maxNoise; }
            set { _maxNoise = value; }
        }
    }
}
