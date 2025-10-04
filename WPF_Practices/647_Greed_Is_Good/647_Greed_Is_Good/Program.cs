using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _647_Greed_Is_Good
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            var result = Score(new int[] { 4, 4, 4, 3, 3 });
            Console.WriteLine(result);

            var result2 = Order("");
            Console.WriteLine(result2);

            var result3 = SumDigPow(90, 100);
            result3.ToList<long>().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }

        public static int Score(int[] dice)
        {
            var score = 0;
            foreach(var item in dice)
            {
                var count = dice.Where(x =>item == x).Count();
                dice = dice.Where(x => item != x).ToArray<int>();

                if (item == 1)
                {
                    score += (count / 3) * 1000 + (count % 3) * 100;
                }
                else if (item == 2)
                {
                    score += (count / 3) * 200;
                }
                else if (item == 3)
                {
                    score += (count / 3) * 300;
                }
                else if (item == 4)
                {
                    score += (count / 3) * 400;
                }
                else if (item == 5)
                {
                    score += (count / 3) * 500 + (count % 3) * 50;
                }
                else if (item == 6)
                {
                    score += (count / 3) * 600;
                }
            }
            return score;
        }

        public static string Order(string words)
        {
            if (words == "")
            {
                return "";
            }
            var inputs = words.Split(' ');
            var result = new string[inputs.Length];
            foreach (string item in inputs)
            {
                int num = 0;
                item.First(x => int.TryParse(x.ToString(), out num));
                if (num != 0)
                {
                    result[num - 1] = item;
                }
            }

            return string.Join(" ", result);
        }

        public static string Order_GoodExample(string words)
        {
            if (string.IsNullOrEmpty(words)) return words;
            return string.Join(" ", words.Split(' ').OrderBy(s => s.ToList().Find(c => char.IsDigit(c))));
        }
         
        public static long[] SumDigPow(long a, long b)
        {
            var numbers = Enumerable.Range((int)a, (int)b - (int)a).Select(x => (long)x).ToList();
            var result = numbers.Where(x => {
                long sum = 0;
                int exp = 1;

                foreach (var c in x.ToString())
                {
                    int i;
                    int.TryParse(c.ToString(), out i);



                    sum += (int)Math.Pow(i, exp);
                    exp++;
                }
                return sum == x;
            });

            return result.ToArray();
        }
    }
}
