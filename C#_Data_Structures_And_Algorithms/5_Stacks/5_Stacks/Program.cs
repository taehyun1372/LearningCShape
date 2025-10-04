using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World \n");

            Stack<char> chars = new Stack<char>();
            foreach (char c in "Let's reverse!")
            {
                chars.Push(c);
            }
            while (chars.Count > 0)
            {
                Console.Write(chars.Pop());
            }
            Console.WriteLine();
            Console.WriteLine("Goodbye World \n");

            Console.WriteLine("----Hanoi Tower----");
            var hanoiTower = new HanoiTower(10);
            hanoiTower.Start();

            Console.ReadLine();
        }
    }

    public class HanoiTower
    {
        public int DiscsCount { get; set; }
        public int MovesCount { get; set; }
        public Stack<int> From { get; set; }
        public Stack<int> To { get; set; }
        public Stack<int> Auxiliary { get; set; }
        public event EventHandler<EventArgs> MoveCompleted;

        public HanoiTower(int discs)
        {
            DiscsCount = discs;
            From = new Stack<int>();
            To = new Stack<int>();
            Auxiliary = new Stack<int>();
            for (int i = 1; i <= discs; i++)
            {
                int size = discs - i + 1;
                From.Push(size);
            }
            MoveCompleted += OnMoveCompleted;
        }

        public void Start()
        {
            DisplayCurrentStatus();

            //Move(From, To);
            //Move(From, Auxiliary); //2
            //Move(To, Auxiliary);

            //Move(From, To); //3

            //Move(Auxiliary, From);
            //Move(Auxiliary, To); //2
            //Move(From, To);

            Move(From, Auxiliary);
            Move(From, To);
            Move(Auxiliary, To);
            Move(From, Auxiliary); //3
            Move(To, From);
            Move(To, Auxiliary);
            Move(From, Auxiliary);

            Move(From, To); //4

            Move(Auxiliary, To); 
            Move(Auxiliary, From); 
            Move(To, From);
            Move(Auxiliary, To); //3
            Move(From, Auxiliary);
            Move(From, To);
            Move(Auxiliary, To);
        }

        public void Move(Stack<int> A, Stack<int> B)
        {
            if (A.Count <= 0)
            {
                Console.WriteLine("There is no disc to move");
                return;
            }

            if (B.Count != 0  && A.Peek() > B.Peek())
            {
                Console.WriteLine("Cannot move a disc onto a smaller disc");
                return;
            }

            B.Push(A.Pop());
            MoveCompleted?.Invoke(this, EventArgs.Empty);
        }

        public void OnMoveCompleted(object sender, EventArgs e)
        {
            MovesCount++;
            Console.WriteLine($"-----{MovesCount} Move-----");
            DisplayCurrentStatus();
        }


        public void DisplayCurrentStatus()
        {
            Console.Write("From >> ");
            this.From.ToList().ForEach(x => Console.Write($"{x} "));
            Console.WriteLine("");
            Console.Write("To >> ");
            this.To.ToList().ForEach(x => Console.Write($"{x} "));
            Console.WriteLine("");
            Console.Write("Aux >> ");
            this.Auxiliary.ToList().ForEach(x => Console.Write($"{x} "));
            Console.WriteLine("");
        }
    }


}
