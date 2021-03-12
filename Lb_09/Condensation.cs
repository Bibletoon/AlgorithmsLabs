using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace AlgorithmsLabs.Nine
{
    internal class Condensation
    {
        private static (int, int) parseTwoInts(string input)
        {
            var splitedInput = input.Split();
            return (Int32.Parse(splitedInput[0]), Int32.Parse(splitedInput[1]));
        }

        private static HashSet<int>[] edjesList;
        private static HashSet<int>[] edjesListInverted;

        private static (int, int[]) GetCondensation()
        {
            var ord = Topsort();
            bool[] nodeChecked = new bool[edjesList.Length];
            int[] components = new int[edjesList.Length];
            int component = 1;

            void Dfs(int index)
            {
                nodeChecked[index] = true;
                components[index] = component;
                foreach (int node in edjesListInverted[index])
                {
                    if (!nodeChecked[node])
                    {
                        Dfs(node);
                    }
                }
            }

            foreach (int i in ord)
            {
                if (!nodeChecked[i])
                {
                    Dfs(i);
                    component++;
                }
            }

            return (component - 1, components);
        }

        public static List<int> Topsort()
        {
            var ord = new List<int>();
            var nodeChecked = new bool[edjesList.Length];

            void Dfs(int index)
            {
                nodeChecked[index] = true;
                foreach (int node in edjesList[index])
                {
                    if (!nodeChecked[node])
                    {
                        Dfs(node);
                    }
                }

                ord.Add(index);
            }

            for (int i = 0; i < edjesList.Length; i++)
            {
                if (!nodeChecked[i])
                {
                    Dfs(i);
                }
            }

            ord.Reverse();
            return ord;
        }

        private static void Program()
        {
            (int n, int m) = parseTwoInts(Console.ReadLine());

            edjesList = new HashSet<int>[n];
            edjesListInverted = new HashSet<int>[n];

            for (int i = 0; i < n; i++)
            {
                edjesList[i] = new HashSet<int>();
                edjesListInverted[i] = new HashSet<int>();
            }

            for (int i = 0; i < m; i++)
            {
                (int u, int v) = parseTwoInts(Console.ReadLine());
                edjesList[u - 1].Add(v - 1);
                edjesListInverted[v - 1].Add(u - 1);
            }

            var (number, condensation) = GetCondensation();
            Console.WriteLine(number);
            Console.WriteLine(String.Join(" ", condensation));
        }

        public static void Main()
        {
            var stackSize = 100000000;
            Thread thread = new Thread(new ThreadStart(Program), stackSize);
            thread.Start();
        }
    }
}