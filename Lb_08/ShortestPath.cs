using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmsLabs.Eight
{
    internal class ShortestPath
    {
        private static bool[] used;
        private static int[] pathLenth;
        private static HashSet<int>[] graph;

        private static (int, int) GetTwoNumbers(string input)
        {
            var splitedInput = input.Split();
            int numberOne = Int32.Parse(splitedInput[0]);
            int numberTwo = Int32.Parse(splitedInput[1]);
            return (numberOne, numberTwo);
        }

        private static void BFS(int num)
        {
            Queue<(int, int)> nodesQueue = new Queue<(int, int)>();
            nodesQueue.Enqueue((num, 0));
            int curNum, depth;
            while (nodesQueue.Count > 0)
            {
                (curNum, depth) = nodesQueue.Dequeue();
                if (!used[curNum])
                {
                    used[curNum] = true;
                    pathLenth[curNum] = depth;
                    foreach (var node in graph[curNum])
                    {
                        if (!used[node]) nodesQueue.Enqueue((node, depth + 1));
                    }
                }
            }
        }

        private static void Main()
        {
            // var inputFile = new StreamReader("pathbge1.in");
            (int n, int m) = GetTwoNumbers(Console.ReadLine());

            graph = new HashSet<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new HashSet<int>();
            }
            for (int i = 0; i < m; i++)
            {
                (int a, int b) = GetTwoNumbers(Console.ReadLine());

                graph[a - 1].Add(b - 1);
                graph[b - 1].Add(a - 1);
            }

            used = new bool[n];
            pathLenth = new int[n];
            BFS(0);

            // inputFile.Close();
            //var outputFile = new StreamWriter("pathbge1.out");
            // outputFile.WriteLine(String.Join(' ', pathLenth));
            foreach (var a in pathLenth)
            {
                Console.Write($"{a} ");
            }
            // outputFile.Close();
        }
    }
}