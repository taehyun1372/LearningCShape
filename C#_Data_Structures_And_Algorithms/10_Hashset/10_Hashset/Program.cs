using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Hashset
{
    public enum PoolTypeEnum
    {
        RECREATION,
        COMPETITION,
        THERMAL,
        KIDS
    };
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> usedCoupons = new HashSet<int>();
            do
            {
                Console.Write("Enter the coupn number: ");
                string couponString = Console.ReadLine();
                if (int.TryParse(couponString, out int coupon))
                {
                    if (usedCoupons.Contains(coupon))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("It has been already used :-)");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        usedCoupons.Add(coupon);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("They you! :-)");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (var item in usedCoupons)
                    {
                        Console.WriteLine($"id : {item.ToString()}");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                }
            } while (true);

            Dictionary<PoolTypeEnum, HashSet<int>> tickets = new Dictionary<PoolTypeEnum, HashSet<int>>()
            {
                { PoolTypeEnum.RECREATION, new HashSet<int>() },
                { PoolTypeEnum.COMPETITION, new HashSet<int>() },
                { PoolTypeEnum.THERMAL, new HashSet<int>() },
                { PoolTypeEnum.KIDS, new HashSet<int>() }
            };

            for (int i = 1; i < 100; i++)
            {
                foreach (KeyValuePair<PoolTypeEnum, HashSet<int>> type in tickets)
                {
                    if (GetRandomBoolean())
                    {
                        type.Value.Add(i);
                    }
                }
            }

            foreach(KeyValuePair<PoolTypeEnum, HashSet<int>> type in tickets)
            {
                Console.WriteLine($"{type.Key.ToString()} List : {type.Value.Count()}");
                foreach(int item in type.Value)
                {
                    Console.Write(item);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            PoolTypeEnum maxVisitors = tickets
                .OrderByDescending(t => t.Value.Count)
                .Select(t => t.Key)
                .FirstOrDefault();
            Console.WriteLine($"Pool {maxVisitors.ToString().ToLower()} was the most popular.");

            HashSet<int> any = new HashSet<int>(tickets[PoolTypeEnum.RECREATION]);
            any.UnionWith(tickets[PoolTypeEnum.COMPETITION]);
            any.UnionWith(tickets[PoolTypeEnum.THERMAL]);
            any.UnionWith(tickets[PoolTypeEnum.KIDS]);
            Console.WriteLine($"{any.Count} people visited at least one pool");

            HashSet<int> none = new HashSet<int>();
            for(int i = 0; i < 100; i++)
            {
                none.Add(i);
            }
            none.ExceptWith(tickets[PoolTypeEnum.RECREATION]);
            none.ExceptWith(tickets[PoolTypeEnum.COMPETITION]);
            none.ExceptWith(tickets[PoolTypeEnum.THERMAL]);
            none.ExceptWith(tickets[PoolTypeEnum.KIDS]);
            Console.WriteLine($"{none.Count()} people didn't go any pool");
            foreach(var item in none)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine();
            HashSet<int> all = new HashSet<int>(tickets[PoolTypeEnum.RECREATION]);
            all.IntersectWith(tickets[PoolTypeEnum.RECREATION]);
            all.IntersectWith(tickets[PoolTypeEnum.COMPETITION]);
            all.IntersectWith(tickets[PoolTypeEnum.THERMAL]);
            all.IntersectWith(tickets[PoolTypeEnum.KIDS]);
            Console.WriteLine($"{none.Count()} people went all pools");
            foreach (var item in all)
            {
                Console.Write(item);
                Console.Write(" ");
            }

            HashSet<string> normalSet = new HashSet<string>();
            normalSet.Add("Marcin");
            normalSet.Add("Mary");
            normalSet.Add("James");
            normalSet.Add("Albert");
            normalSet.Add("Lily");
            normalSet.Add("Emily");
            normalSet.Add("marcin");
            normalSet.Add("James");
            normalSet.Add("Jane");
            normalSet.Add("Mary");

            Console.WriteLine("A list of items in a normal set");
            foreach(var item in normalSet)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine();

            List<string> items = new List<string>() { "Marcin", "Mary", "James", "Albert", "Lily",
            "Emily", "marcin", "James", "Jane", "Mary"};
            SortedSet<string> sortedSet = new SortedSet<string>(items, Comparer<string>.Create((a, b) =>
            a.ToLower().CompareTo(b.ToLower())));


            
            foreach(var item in items)
            {
                sortedSet.Add(item);
            }

            Console.WriteLine("A list of items in a sorted set");
            foreach (var item in sortedSet)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine();


            Console.ReadLine();

        }
        private static Random random = new Random();
        private static bool GetRandomBoolean()
        {
            return random.Next(2) == 1;
        }
    }
}
