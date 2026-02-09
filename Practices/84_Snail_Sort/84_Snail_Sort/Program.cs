using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _84_Snail_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Something");

            var testee1 = new int[][] {
            new int[]{1, 2, 3},
            new int[]{4, 5, 6},
            new int[]{7, 8, 9},
            new int[]{10, 11, 12 }
            };

            var result1 = SnailSolution.Snail(testee1);



            foreach(var item in result1)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine("");

            var testee2 = new int[][] {
            new int[]{100, 200, 300, 400, 500},
            new int[]{600, 700, 800, 900, 1000},
            new int[]{1100, 1200, 1300, 1400, 1500},
            new int[]{1600, 1700, 1800, 1900, 2000 }
            };

            var result2 = SnailSolution.Snail(testee2);

            foreach (var item in result2)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine("");

            Console.WriteLine("Happening");
            Console.ReadLine();


        }
    }

    public class SnailSolution
    {
        public enum Direction
        {
            right,
            bottom,
            left,
            top
        }

        public static int[] Snail(int[][] array)
        {
            var direction = Direction.right;

            if (array.Length < 1)
            {
                return null;
            }
            if (array[0].Length < 1)
            {
                return null;
            }

            var rowNum = array.Length;
            var colNum = array[0].Length;

            var rowIndex = 0;
            var colIndex = 0;

            var topLimit = 0;
            var bottomLimit = rowNum - 1;
            var rightLimit = colNum - 1;
            var leftLimit = 0;

            Console.WriteLine($"row : {rowNum}");
            Console.WriteLine($"col : {colNum}");

            int[] result = new int[rowNum * colNum];
            result[0] = array[0][0];

            for (int i = 1; i < result.Length; i++)
            {

                if (direction == Direction.right)
                {
                    colIndex++;

                    if (colIndex >= rightLimit)
                    {
                        direction = Direction.bottom;
                        topLimit++;
                    }

                }
                else if (direction == Direction.bottom)
                {
                    rowIndex++;

                    if (rowIndex >= bottomLimit)
                    {
                        direction = Direction.left;
                        rightLimit--;
                    }
                }
                else if (direction == Direction.left)
                {
                    colIndex--;

                    if (colIndex <= leftLimit)
                    {
                        direction = Direction.top;
                        bottomLimit--;
                    }
                }
                else if (direction == Direction.top)
                {
                    rowIndex--;

                    if (rowIndex <= topLimit)
                    {
                        direction = Direction.right;
                        leftLimit++;
                    }
                }

                result[i] = array[rowIndex][colIndex];
            }
            return result;
        }

        
    }
}
