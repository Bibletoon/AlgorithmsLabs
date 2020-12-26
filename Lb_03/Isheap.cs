using System;
using System.IO;

namespace AlgorithmsLabs.Third
{
    class IsHeap
    {
        static void Main(string[] args)
        {
            StreamReader inputFile = new StreamReader("isheap.in");
            int n = Int32.Parse(inputFile.ReadLine());
            string[] arr = inputFile.ReadLine().Split();
            inputFile.Close();
            bool isHeap = true;
            for (int i = 0; i < n / 2; i++)
            {
                if (2 * i + 2 <= n && Int32.Parse(arr[i]) > Int32.Parse(arr[2 * i + 1]))
                {
                    isHeap = false;
                    break;
                }
                if (2 * i + 3 <= n && Int32.Parse(arr[i]) > Int32.Parse(arr[2 * i + 2]))
                {
                    isHeap = false;
                    break;
                }

            }
            StreamWriter outputFile = new StreamWriter("isheap.out");
            if (isHeap)
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