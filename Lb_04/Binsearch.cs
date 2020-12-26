using System;
using System.IO;


namespace AlgorithmsLabs.Fourth
{
    class BinSearch
    {
        public static int LowerBound(int[] array,int key)
        {
            int l = 0;
            int r = array.Length - 1;
            while (l<r)
            {
                int mid = (l + r) / 2;
                if (key <= array[mid])
                {
                    r = mid;
                } else
                {
                    l = mid+1;
                }
            }
            return (array[l] == key) ? l+1: -1;
        }

        public static int UpperBound(int[] array, int key)
        {
            int l = 0;
            int r = array.Length - 1;
            while (l < r)
            {
                int mid = (l + r + 1) / 2;
                if (key >= array[mid])
                {
                    l = mid;
                }
                else
                {
                    r = mid - 1;
                }
            }
            return (array[r] == key) ? r+1 : -1;
        }

    }

    class BinSearchCommands
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            int[] array = new int[n];
            string[] rawArray = Console.ReadLine().Split();
            for (int i=0;i<n;i++)
            {
                array[i] = Int32.Parse(rawArray[i]);
            }
            string inp = Console.ReadLine();
            inp = Console.ReadLine();
            foreach (string num in inp.Split())
            {
                Console.WriteLine($"{BinSearch.LowerBound(array, Int32.Parse(num))} {BinSearch.UpperBound(array, Int32.Parse(num))}");
            }
        }
    }
}