using System;
using System.IO;

namespace AlgorithmsLabs.Second
{
    class AntiQSort
    {
        static void Main(string[] args)
        {
            StreamReader inputFile = new StreamReader("antiqs.in");
            int n = Int32.Parse(inputFile.ReadLine());
            inputFile.Close();
            int mid;
            int[] arr = new int[n];
            arr[0] = 1;
            if (n > 1)
            {
                arr[1] = 2;
            }
            for (int i = 3; i <= n; i++)
            {
                mid = (i - 1) / 2;
                arr[i - 1] = arr[mid];
                arr[mid] = i;
            }
            StreamWriter outputFile = new StreamWriter("antiqs.out");
            outputFile.WriteLine(String.Join(" ", arr));
            outputFile.Close();
        }
    }
}