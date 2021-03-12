using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace AlgorithmsLabs.Nine
{
    internal class Hamiltonian
    {
        private static (int, int) parseTwoInts(string input)
        {
            var splitedInput = input.Split();
            return (Int32.Parse(splitedInput[0]), Int32.Parse(splitedInput[1]));
        }

        private static HashSet<int>[] edjesList;
        private static HashSet<int>[] parents;

        private static bool CheckHamiltonianPath()
        {
            int n = edjesList.Length;
            bool[] used = new bool[n];
            HashSet<int> deleted = new HashSet<int>();
            bool HasNoParents(int node)
            {
                var res = parents[node].Select((i) => !deleted.Contains(i)).Aggregate(false, (a, b) => a | b);
                return !res;
            }

            int? FindSource(int node)
            {
                var res = edjesList[node].Where((u) => HasNoParents(u)).ToList();
                if (res.Count() == 0)
                {
                    return null;
                }

                return res[0];
            }

            int? source = null;

            for (int i = 0; i < n; i++)
            {
                if (HasNoParents(i))
                {
                    if (source != null)
                    {
                        return false;
                    }

                    source = i;
                }
            }

            deleted.Add(source.Value);
            while (deleted.Count < n)
            {
                source = FindSource(source.Value);
                if (source == null)
                {
                    return false;
                }

                deleted.Add(source.Value);
            }

            return true;
        }


        private static void Program()
        {
            (int n, int m) = parseTwoInts(Console.ReadLine());

            edjesList = new HashSet<int>[n];
            parents = new HashSet<int>[n];
            for (int i = 0; i < n; i++)
            {
                edjesList[i] = new HashSet<int>();
                parents[i] = new HashSet<int>();
            }

            for (int i = 0; i < m; i++)
            {
                (int u, int v) = parseTwoInts(Console.ReadLine());
                edjesList[u - 1].Add(v - 1);
                parents[v - 1].Add(u - 1);
            }

            var res = CheckHamiltonianPath();
            if (res)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
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