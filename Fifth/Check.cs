using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmsLabs.Fifth
{
    class TreeCheck
    {
        static bool CheckValid((long, long,long)[] tree)
        {
            Stack<(long,long,long)> stack = new Stack<(long, long,long)>();
            stack.Push((1,Int64.MaxValue, Int64.MinValue));
            while (stack.Count > 0)
            {
                var (i, lessThan,greaterThan) = stack.Pop();
                var (key, left, right) = tree[i];
                if (key <= greaterThan || key >= lessThan)
                {
                    return false;
                }
                if (left != 0)
                {
                    stack.Push((left,key,greaterThan));
                }

                if (right != 0)
                {
                    stack.Push((right,lessThan,key));
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            StreamReader input = new StreamReader("check.in");
            long n = Int64.Parse(input.ReadLine());
            (long, long,long)[] tree = new (long, long,long)[n+1];
            for (long i = 1; i <= n; i++)
            {
                string[] rawInp = input.ReadLine().Split();
                tree[i] = (Int64.Parse(rawInp[0]), Int64.Parse(rawInp[1]), Int64.Parse(rawInp[2]));
            }

            StreamWriter outputFile = new StreamWriter("check.out");
            
            if (n==0 || CheckValid(tree))
            {
                outputFile.WriteLine("YES");
            }
            else
            {
                outputFile.WriteLine("NO");
            }
            outputFile.Close();
        }
    }
}