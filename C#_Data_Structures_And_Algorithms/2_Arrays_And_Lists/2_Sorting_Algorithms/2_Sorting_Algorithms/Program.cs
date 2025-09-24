using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Sorting_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Wolrd");
            int[] testee1 = { -11, 12, -42, 0, 1, 90, 68, 6, -9};
            int[] testee2 = { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            int[] testee3 = { 8, 3, 5, 1, 4 };
            int[] testee4 = { 4, -10, 2, 12, 99, -100};

            SelectionSort(testee1);
            DisplayArray(testee1);
            InsertingSort(testee2);
            DisplayArray(testee2);
            InsertingSort(testee3);
            DisplayArray(testee3);
            InsertingSort2(testee4);
            DisplayArray(testee4);

            Console.WriteLine("Goodbye Wolrd");
            Console.ReadLine();
        }

        static void SelectionSort(int[] input)
        {
            for (int j = 0; j < input.Length; j++)
            {
                int lowest = input[j];
                int index = j;
                for (int i = j; i < input.Length; i++)
                {
                    if (input[i] < lowest)
                    {
                        lowest = input[i];
                        index = i;
                    }
                }

                int temp = input[j];
                input[j] = lowest;
                input[index] = temp;
            }
        }

        static void InsertingSort(int[] input)
        {

            for (int sortedIndex = 1; sortedIndex < input.Length; sortedIndex++)
            {
                var index = sortedIndex;

                while(input[index] < input[index - 1]) //Check if the new number sattled in right position. 
                {
                    Swap(input, index, index - 1); //Swap the numbers if it is not yet correct position 
                    index--;
                    if (index == 0) break; //Reach the end of the array.
                }
            }
        }

        static void InsertingSort2(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && array[j].CompareTo(array[j - 1]) < 0)
                {
                    Swap(array, j, j - 1);
                    j--;
                }
            }
        }

        static void Swap(int[] target, int index1, int index2)
        {
            var temp = target[index2];
            target[index2] = target[index1];
            target[index1] = temp;
        }



        static void DisplayArray(int[] input)
        {
            foreach (int item in input)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

    }
}
