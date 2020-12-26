using System;
using System.IO;

namespace AlgorithmsLabs.Second
{
    class KStatistics
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            int[] arr = new int[n];
            for (int i =0;i<n;i++)
            {
                arr[i] = Int32.Parse(input[i]);
            }
            QS(arr, 0, n - 1);
            Console.WriteLine(String.Join(" ",arr));
        }

        static void QS(int[] arr, int L, int R)
        {
            Random rnd = new Random();
            int i = L;
            int j = R;
            int x = arr[rnd.Next(L,R)];
            do
            {
                while (arr[i]<x) { i++; }
                while (arr[j]>x) { j--; }
                if (i<=j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (j>L)
            {
                QS(arr, L, j);
            }
            if (i<R)
            {
                QS(arr, i, R);
            }
        }
    }
}