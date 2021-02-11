using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace AlgorithmsLabs.Eight
{
    internal class DisorientationCheck
    {
        private static int[] _parseStringOfInts(string input)
        {
            List<int> l = new List<int>();
            foreach (var a in input.Split())
            {
                //Added to fix error with pcms shit tests
                try
                {
                    l.Add(int.Parse(a));
                }
                catch
                {
                }
            }

            return l.ToArray();
        }

        private static bool checkMatrix(int size, int[][] martix)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = i; j < size; j++)
                {
                    if (i == j && martix[i][j] != 0) return false;
                    if (i != j && martix[i][j] != martix[j][i]) return false;
                }
            }

            return true;
        }

        private static void Main()
        {
            StreamReader inputFile = new StreamReader("input.txt");
            int n = Int32.Parse(inputFile.ReadLine());
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = _parseStringOfInts(inputFile.ReadLine());
            }

            inputFile.Close();

            var outputFile = new StreamWriter("output.txt");

            outputFile.WriteLine(checkMatrix(n, matrix) ? "YES" : "NO");

            outputFile.Close();
        }
    }
}