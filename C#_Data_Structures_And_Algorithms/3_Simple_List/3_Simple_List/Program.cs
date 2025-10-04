using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _3_Simple_List
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(5);
            arrayList.AddRange(new int[] { 6, -7, 8 });
            DisplayElement(arrayList);
            arrayList.AddRange(new object[] { "Marcin", "Mary" });
            DisplayElement(arrayList);
            arrayList.Insert(5, 7.8);
            DisplayElement(arrayList);

            var third = (int)arrayList[2];
            Console.WriteLine(third + 3);
            Console.WriteLine(arrayList.Count);
            Console.WriteLine(arrayList.Capacity);

            bool containsMary = arrayList.Contains("Mary");
            Console.WriteLine(containsMary);

            Console.WriteLine(arrayList.IndexOf("Mary"));
            arrayList.Remove("Mary");
            DisplayElement(arrayList);

            Console.WriteLine("-------Generic List--------");
            List<double> numbers = new List<double>();
            do
            {
                Console.WriteLine("Enther the number");
                string numberString = Console.ReadLine();
                if (!double.TryParse(numberString, out double number))
                {
                    break;
                }
                numbers.Add(number);
                Console.WriteLine($"The average value is {numbers.Average()}");
            } while (true);

            List<Person> people = new List<Person>();
            people.Add(new Person() { Name = "Marcin", Country = CountryEnum.PL, Age = 29 });
            people.Add(new Person() { Name = "Sabrin", Country = CountryEnum.DE, Age = 25 });
            people.Add(new Person() { Name = "Ann", Country = CountryEnum.PL, Age = 31 });

            people.OrderBy(p => p.Name).ToList().ForEach(p => Console.WriteLine($"{p.Name} {p.Age} {p.Country}"));

            people.Where(p => p.Age <= 30)
                .OrderBy(p => p.Name)
                .Select(p => p.Name)
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            Console.WriteLine("-------Sorted List--------");
            SortedList<string, Person> sortedPeople = new SortedList<string, Person>();
            sortedPeople.Add("Mercin", new Person() { Name="Marcin", Age=29, Country=CountryEnum.PL });
            sortedPeople.Add("Sabine", new Person() { Name = "Sabine", Age = 25, Country = CountryEnum.DE });
            sortedPeople.Add("Ann", new Person() { Name = "Ann", Age = 31, Country = CountryEnum.PL });

            sortedPeople.ToList()
                .ForEach(p => Console.WriteLine($"{p.Key}"));

            Console.WriteLine("-------Linked List--------");
               
            Page page1 = new Page() { Content = "1 In computing, a process that is blocked is waiting for some event, such as a resource becoming available or the completion of an I/O operation.[1] Once the event occurs for which the process is waiting (\" is blocked on\"), the process is advanced from blocked state to an imminent one, such as runnable." };
            Page page2 = new Page() { Content = "2 In a multitasking computer system, individual tasks, or threads of execution, must share the resources of the system. Shared resources include: the CPU, network and network interfaces, memory and disk." };
            Page page3 = new Page() { Content = "3 When one task is using a resource, it is generally not possible, or desirable, for another task to access it. The techniques of mutual exclusion are used to prevent this concurrent use. When the other task is blocked, it is unable to execute until the first task has finished using the shared resource." };
            Page page4 = new Page() { Content = "4 Programming languages and scheduling algorithms are designed to minimize the over-all effect of blocking. A process that blocks may prevent local work-tasks from progressing. In this case \"blocking\" often is seen as not wanted.[2] However, such work-tasks may instead have been assigned to independent processes, where halting one has little to no effect on the others, since scheduling will continue. An example is \"blocking on a channel\" where passively waiting for the other part (i.e. no polling or spin loop) is part of the semantics of channels.[3] Correctly engineered, any of these may be used to implement reactive systems.[clarification needed]" };

            LinkedList<Page> pages = new LinkedList<Page>();
            LinkedListNode<Page> nodepage2 = pages.AddFirst(page2);
            pages.AddLast(page3);
            pages.AddLast(page4);
            pages.AddBefore(nodepage2, page1);

            LinkedListNode<Page> current = pages.First;
            int indexNumber = 1;
            while (current != null)
            {
                Console.Clear();
                string numberString = $"-{indexNumber}-";
                int leadingSpace = (90 - numberString.Length) / 2;
                Console.WriteLine(numberString.PadLeft(leadingSpace + numberString.Length));
                Console.WriteLine();

                string content = current.Value.Content;
                for (int i = 0; i < content.Length; i += 90)
                {
                    string line = content.Substring(i);
                    line = line.Length > 90 ? line.Substring(0, 90) : line;
                    Console.WriteLine(line);
                }

                Console.WriteLine();
                Console.WriteLine($"Quote from \"Windows Application Development Cookbook\" by Marcin Jamro, { Environment.NewLine} " +
                    $"published by Packt Publishing in 2016.");
                Console.WriteLine();
                Console.Write(current.Previous != null ? "< PREVIOUS [P]" : GetSpaces(14));
                Console.Write(current.Next != null ? "[N] NEXT >".PadLeft(76) : string.Empty);
                Console.WriteLine();
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.N:
                        if (current.Next != null)
                        {
                            current = current.Next;
                            indexNumber++;
                        }
                        break;
                    case ConsoleKey.P:
                        if (current.Previous != null)
                        {
                            current = current.Previous;
                            indexNumber--;
                        }
                        break;
                    default:
                        return;
                }
            }

            Console.WriteLine("-------Circular List--------");

            Console.ReadLine();
        }



        private static string GetSpaces(int number)
        {
            string result = string.Empty;
            for (int i = 0; i < number; i++)
            {
                result += " ";
            }
            return result;
        }

        static void DisplayElement(ArrayList array)
        {
            foreach(var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("");
        }
    }
    public class CircularLinkedList<T> : LinkedList<T>
    {
        public new IEnumerator GetEnumerator()
        {
            return new CircularLinkedListEnumerator<T>(this);
        }
    }

    public class CircularLinkedListEnumerator<T> : IEnumerator<T>
    {
        private LinkedListNode<T> _current;
        public T Current => _current.Value;
        object IEnumerator.Current => Current;

        public CircularLinkedListEnumerator(LinkedList<T> list)
        {
            _current = list.First;
        }

        public bool MoveNext()
        {
            if(_current == null)
            {
                return false;
            }
            _current = _current.Next ?? _current.List.First;
            return true;
        }

        public void Reset()
        {
            _current = _current.List.First;
        }

        public void Dispose()
        {
        }
    }

    public class Page
    {
        public string Content { get; set; }
    }



    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public CountryEnum Country { get; set; }

    }

    public enum CountryEnum
    {
        PL,
        UK,
        DE
    }
}
