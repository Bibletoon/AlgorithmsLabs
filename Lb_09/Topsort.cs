using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace AlgorithmsLabs.Nine
{
    internal class Topsort
    {
        private static (int, int) parseTwoInts(string input)
        {
            var splitedInput = input.Split();
            return (Int32.Parse(splitedInput[0]), Int32.Parse(splitedInput[1]));
        }

        private static HashSet<int>[] edjesList;
        private static int[] nodeChecked;
        private static int[] nodeNumber;
        private static int curentNum;
        private static bool cant = false;

        private static void TopologicalSort(int index)
        {
            nodeChecked[index] = 1;
            foreach (int node in edjesList[index])
            {
                if (nodeChecked[node] == 0)
                {
                    TopologicalSort(node);
                }
                else if (nodeChecked[node] == 1)
                {
                    cant = true;
                    return;
                }
            }

            nodeChecked[index] = 2;
            nodeNumber[curentNum] = index + 1;
            curentNum--;
        }

        private static void Program()
        {
            var (n, m) = parseTwoInts(Console.ReadLine());
            edjesList = new HashSet<int>[n];
            nodeChecked = new int[n];
            nodeNumber = new int[n];
            curentNum = n - 1;
            for (int i = 0; i < n; i++)
            {
                edjesList[i] = new HashSet<int>();
            }

            for (int i = 0; i < m; i++)
            {
                var (from, to) = parseTwoInts(Console.ReadLine());
                edjesList[from - 1].Add(to - 1);
            }

            bool w = true;
            for (int i = 0; i < n; i++)
            {
                if (nodeChecked[i] == 0)
                {
                    TopologicalSort(i);
                    if (cant)
                    {
                        Console.WriteLine(-1);
                        w = false;
                        break;
                    }
                }
            }

            if (w)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(nodeNumber[i] + " ");
                }
            }
            
        }

        public static void Main()
        {
            var stackSize = 100000000;
            Thread thread = new Thread(new ThreadStart(Program), stackSize);
            thread.Start();
        }
    }
}