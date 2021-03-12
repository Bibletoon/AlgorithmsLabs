using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace AlgorithmsLabs.Nine
{
    internal class Bipartite
    {
        private static (int, int) parseTwoInts(string input)
        {
            var splitedInput = input.Split();
            return (Int32.Parse(splitedInput[0]), Int32.Parse(splitedInput[1]));
        }

        private static HashSet<int>[] edjesList;
        private static int[] nodeChecked;

        private static bool Dfs(int index, int color)
        {
            nodeChecked[index] = 1 + color % 2;
            foreach (int node in edjesList[index])
            {
                if (nodeChecked[node] == 0)
                {
                    bool res = Dfs(node, 1 + color % 2);
                    if (res == false)
                    {
                        return res;
                    }
                }
                else if (nodeChecked[node] != color)
                {
                    return false;
                }
            }

            return true;
        }

        private static void Program()
        {
            (int n, int m) = parseTwoInts(Console.ReadLine());
            nodeChecked = new int[n];
            edjesList = new HashSet<int>[n];
            for (int i = 0; i < n; i++)
            {
                edjesList[i] = new HashSet<int>();
            }

            for (int i = 0; i < m; i++)
            {
                (int u, int v) = parseTwoInts(Console.ReadLine());
                edjesList[u - 1].Add(v - 1);
                edjesList[v - 1].Add(u - 1);
            }

            bool res = true;
            for (int i = 0; i < n; i++)
            {
                if (nodeChecked[i] == 0)
                {
                    res = Dfs(i, 1);
                    if (!res)
                    {
                        break;
                    }
                }
            }

            if (!res)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
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