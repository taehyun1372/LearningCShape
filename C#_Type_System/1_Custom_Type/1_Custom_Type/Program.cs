using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Custom_Type
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var angle = new Angle(0);
            var speed = new Speed(10.1);

            var slowSpeed = new Speed(10);
            var fastSpeed = new Speed(30);
            var outOfRange = slowSpeed - fastSpeed;
            Console.WriteLine(outOfRange); //Double negative value
            var elapsedTime = new TimeSpan(0, 1, 30);
            var x = slowSpeed * elapsedTime.TotalSeconds;
            Console.WriteLine(x.GetType());


            Console.WriteLine($"The second is {elapsedTime.Seconds}");
            Console.WriteLine($"The total second is {elapsedTime.TotalSeconds}");
            Console.WriteLine($"When double is needed, compiler extracts the value implicitly {speed * 1}");

            var result = Utils.Displacement(angle: angle, speed: slowSpeed, elapsedTime : elapsedTime);


            Console.WriteLine(result.Item1);
            Console.WriteLine(result.Item2);
            Console.ReadLine();
        }

       
    }

    public class Utils
    {
        public static (double, double) Displacement(Angle angle, Speed speed, TimeSpan elapsedTime)
        {
            var x = speed * elapsedTime.TotalSeconds * Math.Cos(angle);
            var y = speed * elapsedTime.TotalSeconds * Math.Sin(angle);
            return (x, y);
        }
    }


    public class Angle
    {
        private double _value;
        public double Value
        {
            get { return _value; }
        }

        public static implicit operator double(Angle angle)
        {
            return angle.Value;
        }

        public Angle(double value)
        {
            

            if ( value < 0 )
            {
                throw new ArgumentOutOfRangeException(paramName: nameof(Value), message: "Angle must be positive");
            }
            _value = value;
        }
    }

    public class Speed
    {
        private double _value;
        public double Value
        {
            get { return _value; }
        }

        public static implicit operator double(Speed speed)
        {
            return speed.Value;
        }

        public Speed(double value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(paramName: nameof(Value), message: "Spped must be positive");
            }
            _value = value;
        }
    }
}
