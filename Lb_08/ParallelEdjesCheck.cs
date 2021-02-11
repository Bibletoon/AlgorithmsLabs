using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmsLabs.Eight
{
    internal class ParallelEdjesCheck
    {
        private static (int, int) GetTwoNumbers(string input)
        {
            var splitedInput = input.Split();
            int numberOne = Int32.Parse(splitedInput[0]);
            int numberTwo = Int32.Parse(splitedInput[1]);
            return (numberOne, numberTwo);
        }

        private static void Main()
        {
            var inputFile = new StreamReader("input.txt");
            (int n, int m) = GetTwoNumbers(inputFile.ReadLine());

            List<int>[] edjeList = new List<int>[n];
            bool result = false;
            for (int i = 0; i < m; i++)
            {
                (int a, int b) = GetTwoNumbers(inputFile.ReadLine());
                if ((edjeList[b - 1]?.Contains(a - 1) ?? (edjeList[b - 1] = new List<int>()).Contains(a - 1)) || (edjeList[a - 1]?.Contains(b - 1) ?? (edjeList[a - 1] = new List<int>()).Contains(b - 1)))
                {
                    result = true;
                    break;
                }

                if (edjeList[a - 1] is null) edjeList[a - 1] = new List<int>();
                edjeList[a - 1].Add(b - 1);
            }

            inputFile.Close();
            var outputFile = new StreamWriter("output.txt");
            outputFile.WriteLine(result ? "YES" : "NO");
            outputFile.Close();
        }
    }
}