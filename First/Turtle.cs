using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AlgorithmsLabs.First
{
    class Turtle
    {
        static int[,][] GetMaxVal(int w, int h, int[,][] arr)
        {
            int left = 0;
            if (w > 0)
            {
                if (arr[h, w-1][1] == -1)
                {
                    arr = GetMaxVal(w-1, h, arr);
                }
                left = arr[h, w-1][0];
            }
            int down = 0;
            if (h > 0)
            {
                if (arr[h-1, w][1] == -1)
                {
                    arr = GetMaxVal(w, h-1, arr);
                }
                down = arr[h-1, w][0];
            }
            if (left > down)
            {
                arr[h, w][0] += left;
            }
            else
            {
                arr[h, w][0] += down;
            }
            arr[h, w][1] = 1;
            return arr;
                    
        }

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("turtle.in");
            int w = Int32.Parse(input[0].Split()[1]);
            int h = Int32.Parse(input[0].Split()[0]);
            int[,][] arr = new int[h,w][];
            for (int i=0;i<h;i++)
            {
                string[] line = input[i + 1].Split();
                for (int j=0;j<w;j++)
                {
                    arr[h-i-1,j] = new int[2] {Int32.Parse(line[j]) , -1};
                }
            }
            arr[0, 0][1] = 1;
            arr = GetMaxVal(w - 1, h - 1, arr);
            File.WriteAllText("turtle.out",arr[h - 1, w - 1][0].ToString());
        }
    }
}