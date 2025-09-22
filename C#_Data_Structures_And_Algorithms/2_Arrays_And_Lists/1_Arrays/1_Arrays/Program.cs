using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Arrays
{
    public enum TerrainEnum
    {
        GRASS,
        SAND,
        WATER,
        WALL
    }

    public static class TerrainEnumExtensions
    {
        public static ConsoleColor GetColor(this TerrainEnum terrain)
        {
            switch (terrain)
            {
                case TerrainEnum.GRASS: return ConsoleColor.Green;
                case TerrainEnum.SAND: return ConsoleColor.Yellow;
                case TerrainEnum.WATER: return ConsoleColor.Blue;
                default: return ConsoleColor.DarkGray;
            }
        }

        public static Char GetChar(this TerrainEnum terrain)
        {
            switch (terrain)
            {
                case TerrainEnum.GRASS: return '\u201c';
                case TerrainEnum.SAND: return '\u25cb';
                case TerrainEnum.WATER: return '\u2248';
                default: return '\u25cf';
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            int[] numbers = new int[5] { 9, -11, 6, -12, 1};
            foreach(int item in numbers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----Example Month names----");
            string[] months = new string[12];
            for (int month = 1; month <= 12; month++)
            {
                DateTime firstDay = new DateTime(DateTime.Now.Year, month, 1);
                string name = firstDay.ToString("MMMM");
                months[month - 1] = name;
            }

            foreach(string month in months)
            {
                Console.WriteLine($"-> {month}");
            }

            Console.WriteLine("----Multiplicaiton table----");
            int[,] results = new int[10, 10];
            for (int i = 0; i < results.GetLength(0); i++)
            {
                for (int j = 0; j< results.GetLength(1); j++)
                {
                    results[i, j] = (i + 1) * (j + 1);
                }
            }

            for (int i = 0; i < results.GetLength(0); i++)
            {
                for (int j = 0; j < results.GetLength(1); j++)
                {
                    Console.Write("{0, 4}", results[i, j]);
                }
                Console.WriteLine("");
            }

            Console.WriteLine("----Game map----");
            TerrainEnum[,] map =
            {
                { TerrainEnum.SAND, TerrainEnum.SAND, TerrainEnum.SAND,
                TerrainEnum.SAND, TerrainEnum.GRASS, TerrainEnum.GRASS,
                TerrainEnum.GRASS, TerrainEnum.GRASS, TerrainEnum.GRASS,
                TerrainEnum.GRASS },
                { TerrainEnum.WATER, TerrainEnum.WATER, TerrainEnum.WATER,
                TerrainEnum.WATER, TerrainEnum.WATER, TerrainEnum.WATER,
                TerrainEnum.WATER, TerrainEnum.WALL, TerrainEnum.WATER,
                TerrainEnum.WATER }
            };
            Console.OutputEncoding = UTF8Encoding.UTF8;
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int column = 0; column < map.GetLength(1); column++)
                {
                    Console.ForegroundColor = map[row, column].GetColor();
                    Console.Write(map[row, column].GetChar() + " ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;


            Console.WriteLine("Goodbye World");
            Console.ReadLine();

        }
    }
}
