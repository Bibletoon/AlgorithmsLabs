using System;
using System.IO;

namespace AlgorithmsLabs.Second
{
    class QSort
    {
        static void Main(string[] args)
        {
            StreamReader inputFile = new StreamReader("sort.in");
            int n = Int32.Parse(inputFile.ReadLine());
            string[] rawArr = inputFile.ReadLine().Split();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = Int32.Parse(rawArr[i]);
            }
            QuickSort(arr, 0, arr.Length - 1);
            StreamWriter outputFile = new StreamWriter("sort.out");
            outputFile.WriteLine(String.Join(" ", arr));
            outputFile.Close();
        }

        static int Partition(int[] array, int left, int right)
        {
            Random rnd = new Random();
            int number = rnd.Next(left, right);
            int temp = array[number];
            array[number] = array[right];
            array[right] = temp;
            int marker = left;
            for (int i = left; i <= right; i++)
            {
                if (array[i] <= array[right])
                {
                    temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            return marker - 1;
        }

        static void QuickSort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            int pivot = Partition(array, left, right);
            QuickSort(array, left, pivot - 1);
            QuickSort(array, pivot + 1, right);
        }

    }
}