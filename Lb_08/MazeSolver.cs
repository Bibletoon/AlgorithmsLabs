using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmsLabs.Eight
{
    internal class MazeSolver
    {
        private static char[][] maze;
        private static bool[][] used;

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
            (int n, int m) = GetTwoNumbers(inputFile.ReadLine());
            maze = new char[n][];
            used = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                maze[i] = inputFile.ReadLine().ToCharArray();
                used[i] = new bool[m];
            }

            inputFile.Close();

            (int, int) startPoint = (-1, -1);
            (int, int) endPoint = (-1, -1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (maze[i][j] == 'S') startPoint = (i, j);
                    if (maze[i][j] == 'T') endPoint = (i, j);
                }
            }

            Queue<(int, int, string)> wayVariants = new Queue<(int, int, string)>();
            wayVariants.Enqueue((startPoint.Item1, startPoint.Item2, ""));
            used[startPoint.Item1][startPoint.Item2] = true;
            string result = String.Empty;

            while (wayVariants.Count > 0)
            {
                (int y, int x, string path) = wayVariants.Dequeue();
                if (y == endPoint.Item1 && x == endPoint.Item2)
                {
                    result = path;
                    break;
                }

                if (y != 0 && maze[y - 1][x] != '#' && !used[y-1][x])
                {
                    wayVariants.Enqueue((y - 1, x, path + "U"));
                    used[y - 1][x] = true;
                }

                if (x != 0 && maze[y][x - 1] != '#' && !used[y][x - 1])
                {
                    wayVariants.Enqueue((y, x - 1, path + "L"));
                    used[y][x - 1] = true;
                }

                if (y != n - 1 && maze[y + 1][x] != '#' && !used[y + 1][x])
                {
                    wayVariants.Enqueue((y + 1, x, path + "D"));
                    used[y + 1][x] = true;
                }

                if (x != m - 1 && maze[y][x + 1] != '#' && !used[y][x + 1])
                {
                    wayVariants.Enqueue((y, x + 1, path + "R"));
                    used[y][x + 1] = true;
                }
            }

            var outputFile = new StreamWriter("output.txt");
            if (result == "")
            {
                outputFile.WriteLine(-1);
            }
            else
            {
                outputFile.WriteLine(result.Length);
                outputFile.WriteLine(result);
            }

            outputFile.Close();
        }
    }
}