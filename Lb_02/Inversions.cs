using System;
using System.IO;

namespace AlgorithmsLabs.Second
{
    class Inversions
    {
        public static ulong inversions = 0;
        static void Main(string[] args)
        {
            StreamReader inputFile = new StreamReader("inversions.in");
            int n = Int32.Parse(inputFile.ReadLine());
            string[] rawArr = inputFile.ReadLine().Split();
            inputFile.Close();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = Int32.Parse(rawArr[i]);
            }
            MergeSort(arr);
            StreamWriter outputFile = new StreamWriter("inversions.out");
            outputFile.WriteLine(inversions.ToString());
            outputFile.Close();
        }

        static private int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1) { return arr; }
            int n = arr.Length;
            int[] left = new int[n / 2];
            int[] right = new int[n - (n / 2)];
            for (int i = 0; i < n; i++)
            {
                if (i < n / 2)
                {
                    left[i] = arr[i];
                }
                else
                {
                    right[i - (n / 2)] = arr[i];
                }
            }
            left = MergeSort(left);
            right = MergeSort(right);


            return Merge(left, right, n);
        }

        private static int[] Merge(int[] left, int[] right, int n)
        {
            int[] result = new int[n];
            int leftCounter = 0;
            int rightCounter = 0;
            int leftLen = n / 2;
            int rightLen = n - (n / 2);
            int resCounter = 0;
            while (leftCounter < leftLen && rightCounter < rightLen)
            {
                if (right[rightCounter] < left[leftCounter])
                {
                    result[resCounter] = right[rightCounter];
                    rightCounter++;
                    inversions += (ulong)(leftLen - leftCounter);
                }
                else
                {
                    result[resCounter] = left[leftCounter];
                    leftCounter++;
                }
                resCounter++;
            }
            while (leftCounter < leftLen)
            {
                result[resCounter] = left[leftCounter];
                resCounter++;
                leftCounter++;
            }
            while (rightCounter < rightLen)
            {
                result[resCounter] = right[rightCounter];
                resCounter++;
                rightCounter++;
            }
            return result;
        }
    }
}