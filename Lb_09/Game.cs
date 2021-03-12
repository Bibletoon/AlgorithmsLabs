using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace AlgorithmsLabs.Nine
{
    internal class Game
    {
        private static (int, int) parseTwoInts(string input)
        {
            var splitedInput = input.Split();
            return (Int32.Parse(splitedInput[0]), Int32.Parse(splitedInput[1]));
        }

        private static (int, int, int) parseThreeInts(string input)
        {
            var splitedInput = input.Split();
            return (Int32.Parse(splitedInput[0]), Int32.Parse(splitedInput[1]), Int32.Parse(splitedInput[2]));
        }

        private static HashSet<int>[] edjesList;

        private static bool IsFirstWins(int startPoint)
        {
            int n = edjesList.Length;
            bool[] used = new bool[n];

            bool Dfs(int index)
            {
                used[index] = true;
                foreach (int node in edjesList[index])
                {
                    if (!used[node])
                    {
                        bool res = Dfs(node);
                        if (!res)
                        {
                            return true;
                        }
                    }
                }

                used[index] = false;
                return false;
            }

            return Dfs(startPoint);
        }

        private static void Program()
        {
            (int n, int m, int start) = parseThreeInts(Console.ReadLine());

            edjesList = new HashSet<int>[n];
           
            for (int i = 0; i < n; i++)
            {
                edjesList[i] = new HashSet<int>();
            }

            for (int i = 0; i < m; i++)
            {
                (int u, int v) = parseTwoInts(Console.ReadLine());
                edjesList[u - 1].Add(v - 1);
            }

            if (IsFirstWins(start-1))
            {
                Console.WriteLine("First player wins");
            }
            else
            {
                Console.WriteLine("Second player wins");
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