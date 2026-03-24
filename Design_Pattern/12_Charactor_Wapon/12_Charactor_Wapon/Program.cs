using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Charactor_Wapon
{
    class Program
    {
        static void Main(string[] args)
        {
            IWapon sword = new Sword();
            var charactor = new Worrior();
            charactor.Wapon = sword;

            charactor.Attack();
            charactor.Attack();

            IWapon gun = new Gun();
            charactor.Wapon = gun;

            charactor.Attack();
            charactor.Attack();

            Console.ReadLine();
        }
    }

    public interface IWapon
    {
        void Use();
    }

    public abstract class Wapon : IWapon, IDisposable
    {
        protected int _duration = 1;
        protected bool _disposed = false;
        protected string _name;

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            _disposed = true;
            Console.WriteLine($"[{_name}] is being disposed..");

        }

        public abstract void MakeSound();

        public void Use()
        {
            if (_disposed) return;
            _duration--;
            Console.WriteLine($"Using [{_name}]..Duration left [{_duration}] times..");
            MakeSound();
            if (_duration <= 0) Dispose();
        }
    }

    public class Sword : Wapon
    {
        public Sword()
        {
            _duration = 5;
            _name = "Sword";
        }

        public override void MakeSound()
        {
            Console.WriteLine("Ching..");
        }
    }

    public class Gun : Wapon
    {
        public Gun()
        {
            _duration = 3;
            _name = "Gun";
        }

        public override void MakeSound()
        {
            Console.WriteLine("Bang..");
        }
    }

    public interface ICharactor
    {
        void Attack();
    }

    public abstract class Charactor
    {
        protected IWapon _wapon;
        protected string _name;
        public IWapon Wapon
        {
            get { return _wapon; }
            set { _wapon = value; }

        }
        protected void Attack()
        {
            if (_wapon == null) return;
            Console.WriteLine($"[{_name}]'s attack..");
        }
    }


    public class Worrior : Charactor
    {
        public Worrior()
        {
            _name = "Worrior";
        }

        public void Attack()
        {
            base.Attack();
            _wapon.Use();
            _wapon.Use();
            _wapon.Use();
        }
    }

    public class Archor : Charactor
    {
        public Archor()
        {
            _name = "Archor";
        }
        public void Attack()
        {
            base.Attack();
            _wapon.Use();
        }
    }
}
