using System;
using System.IO;

namespace AlgorithmsLabs.Seven
{
    class AVLCommands
    {
        static void Main()
        {
            StreamReader inputFile = new StreamReader("balance.in");
            int nodeCount = Int32.Parse(inputFile.ReadLine());
            int[] parents = new int[nodeCount];
            int[] height  = new int[nodeCount];
            int[,] childs = new int[nodeCount,2];
            string[] input;
            int left;
            int right;
            input = inputFile.ReadLine().Split();
            left = Int32.Parse(input[1]);
            right = Int32.Parse(input[2]);
            parents[0] = -1;
            childs[0,0] = left-1;
            childs[0, 1] = right-1;
            for (int i = 1; i < nodeCount; i++)
            {
                input = inputFile.ReadLine().Split();
                left = Int32.Parse(input[1]);
                right = Int32.Parse(input[2]);
                if (left != 0)
                {
                    parents[left - 1] = i;
                }

                if (right != 0)
                {
                    parents[right - 1] = i;
                }

                childs[i, 0] = left - 1;
                childs[i, 1] = right - 1;
            }

            inputFile.Close();

            int md;
            for (int i = nodeCount - 1; i >= 0; i--)
            {
                md = 0;
                if (childs[i, 0] != -1 && height[childs[i, 0]] > md)
                {
                    md = height[childs[i, 0]];
                }
                if (childs[i, 1] != -1 && height[childs[i, 1]] > md)
                {
                    md = height[childs[i, 1]];
                }

                height[i] = md+1;
            }

            StreamWriter outputFile = new StreamWriter("balance.out");

            for (int i = 0; i < nodeCount; i++)
            {
                int res = 0;
                if (childs[i, 0] != -1)
                {
                    res -= height[childs[i, 0]];
                }
                if (childs[i, 1] != -1)
                {
                    res += height[childs[i, 1]];
                }

                outputFile.WriteLine(res);
            }
            outputFile.Close();
        }
    }
}