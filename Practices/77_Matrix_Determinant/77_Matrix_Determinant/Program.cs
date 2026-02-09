using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _77_Matrix_Determinant
{
    class Program
    {
        static void Main(string[] args)
        {

            int[][] testee1 = new int[][] 
            { 
                new int[] {1, 2},
                new int[] {3, 4},
            };

            var result = Determinant(testee1);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static int Determinant(int[][] matrix)
        {
            var len = matrix.Length;
            if (len == 2) return SubDeterminant(matrix);
            else
            {
                var polarity = 1;
                for(int i = 0; i < len; i++)
                {
                    matrix[0][i] * polarity * matrix[1].AsSpan();
                    polarity = polarity * - 1;
                }
            }

        }

        public static int SubDeterminant(int[][] matrix)
        {
            var len = matrix.Length;
            if (len == 2) return matrix[0][0] * matrix[len - 1][len - 1] - matrix[0][len - 1] * matrix[len - 1][0];
            else return 0;

        }
    }
}
