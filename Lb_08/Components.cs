using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmsLabs.Eight
{
    internal class Components
    {
        private static bool[] used;
        private static int[] numOfComponent;
        private static HashSet<int>[] graph;

        private static (int, int) GetTwoNumbers(string input)
        {
            var splitedInput = input.Split();
            int numberOne = Int32.Parse(splitedInput[0]);
            int numberTwo = Int32.Parse(splitedInput[1]);
            return (numberOne, numberTwo);
        }

        private static void BFS(int num, int componentNum)
        {
            Queue<int> nodesQueue = new Queue<int>();
            nodesQueue.Enqueue(num);
            int curNum;
            while (nodesQueue.Count > 0)
            {
                curNum = nodesQueue.Dequeue();
                used[curNum] = true;
                numOfComponent[curNum] = componentNum;
                foreach (var node in graph[curNum])
                {
                    if (!used[node]) nodesQueue.Enqueue(node);
                }
            }
        }

        private static void Main()
        {
            //var inputFile = new StreamReader("components.in");
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
            numOfComponent = new int[n];

            int componentNum = 1;
            for (int i = 0; i < n; i++)
            {
                if (!used[i])
                {
                    BFS(i, componentNum);
                    componentNum++;
                }
            }

            //inputFile.Close();
            //var outputFile = new StreamWriter("components.out");
            Console.WriteLine(componentNum - 1);
            foreach (var a in numOfComponent)
            {
                Console.Write($"{a} ");
            }

            //outputFile.Close();
        }
    }
}