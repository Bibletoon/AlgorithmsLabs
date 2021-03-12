using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace AlgorithmsLabs.Nine
{
    internal class Cycle
    {
        private static (int, int) parseTwoInts(string input)
        {
            var splitedInput = input.Split();
            return (Int32.Parse(splitedInput[0]), Int32.Parse(splitedInput[1]));
        }

        private static (int,int) Dfs(int index, HashSet<int>[] edjesList, int[] nodeChecked, int[] parents)
        {
            nodeChecked[index] = 1;
            foreach (var child in edjesList[index])
            {
                if (nodeChecked[child] == 0)
                {
                    parents[child] = index;
                    var res = Dfs(child,edjesList,nodeChecked,parents);
                    if (res.Item1 != -1)
                    {
                        return res;
                    }
                } else if (nodeChecked[child] == 1)
                {
                    return (child,index);
                }
            }

            nodeChecked[index] = 2;
            return (-1,-1);
        }
        

        public static void Program()
        {
            (int n, int m) = parseTwoInts(Console.ReadLine());
                var edjesList = new HashSet<int>[n];
                for (int i = 0; i < n; i++)
                {
                    edjesList[i] = new HashSet<int>();
                }

                var parents = new int[n];
                var nodeChecked = new int[n];
                for (int i = 0; i < m; i++)
                {
                    (int a, int b) = parseTwoInts(Console.ReadLine());
                    edjesList[a - 1].Add(b - 1);
                }

                (int, int) res = (-1,-1);
                for (int i = 0; i < n; i++)
                {
                    if (nodeChecked[i] == 0)
                    {
                        res = Dfs(i,edjesList,nodeChecked,parents);
                        if (res.Item1 != -1)
                        {
                            break;
                        }
                    }
                }

                if (res.Item1 == -1)
                {
                    Console.WriteLine("NO");
                }
                else
                {
                    List<int> cycle = new List<int>();
                    Console.WriteLine("YES");
                    int start = res.Item1;
                    int end = res.Item2;
                    while (end != start)
                    {
                        cycle.Add(end + 1);
                        end = parents[end];
                    }

                    cycle.Add(start + 1);
                    cycle.Reverse();
                    Console.WriteLine(String.Join(" ", cycle.ToArray()));
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