using System;
using System.IO;
using System.Text;

namespace AlgorithmsLabs.Third
{ 
    class RadixSort
    {
        const int NumOfSymbols = 26;
        static string[] CountingSortStrings(string[] arr, int index)
        {
            int[] count = new int[NumOfSymbols];
            for (int i=0;i<arr.Length;i++)
            {
                int nowInd = Encoding.ASCII.GetBytes(arr[i][index].ToString())[0]-97;
                count[nowInd] += 1;
            }
            for (int i=1;i<NumOfSymbols;i++)
            {
                count[i] += count[i - 1];
            }
            string[] resArr = new string[arr.Length];
            for (int i=arr.Length-1;i>=0;i--)
            {
                int nowInd = Encoding.ASCII.GetBytes(arr[i][index].ToString())[0]-97;
                resArr[count[nowInd] - 1] = arr[i];
                count[nowInd] -= 1;
            }
            return resArr;
        }

        static void Main(string[] args)
        {
            string[] inp = Console.ReadLine().Split();
            int n = Int32.Parse(inp[0]);
            int m = Int32.Parse(inp[1]);
            int k = Int32.Parse(inp[2]);
            string[] array = new string[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = Console.ReadLine().Replace("\n", "");
            }
            int index = m-1;
            for (int i=0;i<k;i++)
            {
                array = CountingSortStrings(array, index);
                index--;
            }
            Console.WriteLine(String.Join("\n",array));
        }
    }
}