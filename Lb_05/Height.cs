using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmsLabs.Fifth
{
    class TreeDepth
    {
        static int FindMaxHeight((int, int)[] tree)
        {
            Stack<(int,int)> stack = new Stack<(int, int)>();
            stack.Push((1,0));
            int maxHeight = 0;
            while (stack.Count > 0)
            {
                var (i, height) = stack.Pop();
                var (left, right) = tree[i];
                maxHeight = Math.Max(maxHeight, height + 1);
                if (left != 0)
                {
                    stack.Push((left,height+1));
                }

                if (right != 0)
                {
                    stack.Push((right,height+1));
                }
            }

            return maxHeight;
        }

        static void Main(string[] args)
        {
            StreamReader input = new StreamReader("height.in");
            int n = Int32.Parse(input.ReadLine());
            (int, int)[] tree = new (int, int)[n+1];
            for (int i = 1; i <= n; i++)
            {
                string[] rawInp = input.ReadLine().Split();
                tree[i] = (Int32.Parse(rawInp[1]), Int32.Parse(rawInp[2]));
            }

            int maxHeight=0;
            if (n != 0)
            {
                maxHeight = FindMaxHeight(tree);
            }

            StreamWriter outputFile = new StreamWriter("height.out");
            outputFile.WriteLine(maxHeight);
            outputFile.Close();
        }
    }
}