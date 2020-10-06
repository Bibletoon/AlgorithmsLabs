using System;
using System.IO;

namespace AlgorithmsLabs.Second
{
    class KStatistics
    {
        static void Main(string[] args)
        {
            //string[] input = File.ReadAllLines("kth.in");
            string[] inputA = Console.ReadLine().Split();
            string[] inputB = Console.ReadLine().Split();
            int n = Int32.Parse(inputA[0]);
            int k = Int32.Parse(inputA[1]);
            int A = Int32.Parse(inputB[0]);
            int B = Int32.Parse(inputB[1]);
            int C = Int32.Parse(inputB[2]);
            int[] arr = new int[n];
            arr[0] = Int32.Parse(inputB[3]);
            arr[1] = Int32.Parse(inputB[4]);
            for (int i = 2; i < n; i++)
            {
                arr[i] = A * arr[i - 2] + B * arr[i - 1] + C;
            }
            int result = FidKElement(arr, k - 1, n-1);
            Console.WriteLine(result.ToString());
            //File.WriteAllText("kth.out", result.ToString());
        }

        static int FidKElement(int[] array, int k, int len)
        {
            int left = 0;
            int right = len;
            while (left < right)
            {
                int mid = array[(left + right) / 2];
                int i = left;
                int j = right;
                do
                {
                    while (array[i] < mid)
                    {
                        i++;
                    }
                    while (array[j] > mid)
                    {
                        j--;
                    }
                    if (i <= j)
                    {
                        int tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;

                        i++;
                        j--;
                    }
                } while (i <= j);
                if (k < i)
                {
                    right = j;
                }
                else if (k > j)
                {
                    left = i;
                }
                else
                {
                    return array[k];
                }
            }
            return array[k];
        }

    }
}