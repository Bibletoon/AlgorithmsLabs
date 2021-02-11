using System;
using System.IO;

namespace AlgorithmsLabs.Eight
{
    internal class EdgeListToAdjacencyMatrix
    {
        private static (int, int) GetTwoNumbers(string input)
        {
            var splitedInput = input.Split();
            int numberOne = Int32.Parse(splitedInput[0]);
            int numberTwo = Int32.Parse(splitedInput[1]);
            return (numberOne, numberTwo);
        }

        public static void Main()
        {
            var inputFile = new StreamReader("input.txt");
            var (n, m) = GetTwoNumbers(inputFile.ReadLine());
            int[,] matrix = new int[n,n];
            for (int i = 0; i < m; i++)
            {
                var (y, x) = GetTwoNumbers(inputFile.ReadLine());
                matrix[y - 1, x - 1] = 1;
            }

            var outputFile = new StreamWriter("output.txt");

            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    outputFile.Write($"{matrix[y, x]} ");
                }

                outputFile.WriteLine();
            }
            inputFile.Close();
            outputFile.Close();
        }
    }
}