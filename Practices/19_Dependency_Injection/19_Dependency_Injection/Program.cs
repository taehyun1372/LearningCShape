using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Threading;
using Unity.Lifetime;
using Unity.Resolution;

namespace _19_Dependency_Injection
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            var royCar = new Audi();

            //container.RegisterType<ICar, Ford>(); //Create an instacne every time
            //container.RegisterType<ICar, Ford>(new ContainerControlledLifetimeManager()); //Single ton
            container.RegisterInstance<ICar>(royCar); //Register a specific instance

            Driver mike = container.Resolve<Driver>();
            Driver jake = container.Resolve<Driver>();

            mike.Drive();
            jake.Drive();

            container.RegisterType<IManager, Manager>(new ContainerControlledLifetimeManager());
            container.RegisterType<IEmployee, Employee>(new ContainerControlledLifetimeManager());

            IManager jy = container.Resolve<IManager>(new ParameterOverride("id", 101));
            IEmployee roy = container.Resolve<IEmployee>(new ParameterOverride("id", 1013));

            jy.GetManagerId();
            jy.GetEmployeeId();

            roy.GetManagerId();
            roy.GetEmployeeId();

        }

        public interface ICar
        {
            void Run();
        }

        public interface IDriver
        {
            void Drive();
        }

        public class Driver : IDriver
        {
            private Thread _th;
            private ICar _car;

            public Driver(ICar car)
            {
                _car = car;
            }

            public void Drive()
            {
                _th = new Thread(() => {
                    while (true)
                    {
                        if (_car != null)
                        {
                            _car.Run();
                        }
                        Thread.Sleep(1000);
                    }
                });
                _th.Start();
            }
        }

        public class Ford : ICar
        {
            private int _miles;
            private static int _id;
            public Ford()
            {
                Console.WriteLine($"A Ford has been created {_id}");
                _id++;
            }
            public void Run()
            {
                Console.WriteLine($"The ford has run {_miles} so far");
                _miles += 3;
            }
        }

        public class Audi : ICar
        {
            private int _miles;
            private static int _id;
            public Audi()
            {
                Console.WriteLine($"An Audi has been created {_id}");
                _id++;
            }
            public void Run()
            {
                Console.WriteLine($"The audi has run {_miles} so far");
                _miles += 6;
            }
        }

        public interface IManager
        {
            
            void GetManagerId();
            void GetEmployeeId();
        }

        public interface IEmployee
        {
            void GetManagerId();
            void GetEmployeeId();
        }

        public class Manager : IManager
        {
            private int _id;
            public int Id
            {
                get { return _id; }
            }
            private IEmployee _employee;

            public Manager(int id)
            {
                _id = id;
                Console.WriteLine($"A Manager has been created {_id}");
            }

            public void GetEmployeeId()
            {
                if (_employee != null)
                {
                    _employee.GetEmployeeId();
                }
                
            }

            public void GetManagerId()
            {
                Console.WriteLine($"The manager id is {Id}");
            }
        }

        public class Employee : IEmployee
        {
            private int _id;
            public int Id
            {
                get { return _id; }
            }

            private IManager _manager;

            public Employee(int id)
            {
                _id = id;
                Console.WriteLine($"An Employee has been created {_id}");
            }

            public void GetEmployeeId()
            {
                Console.WriteLine($"The employee id is {Id}");
            }

            public void GetManagerId()
            {
                if (_manager != null)
                {
                    _manager.GetManagerId();
                }
            }
        }


    }
}
