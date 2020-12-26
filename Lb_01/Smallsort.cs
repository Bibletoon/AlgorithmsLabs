using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AlgorithmsLabs.First
{
    class Smallsort
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("smallsort.in");
            int Len = Int32.Parse(input[0]);
            string[] rawArr = input[1].Split();
            int[] arr = new int[Len];
            for (int i = 0; i < Len; i++)
            {
                arr[i] = Int32.Parse(rawArr[i]);
            }
            int n;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        n = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = n;
                    }
                }
            }
            string result = "";
            for (int i = 0; i < Len; i++)
            {
                result += arr[i].ToString();
                result += " ";
            }
            File.WriteAllText("smallsort.out", result);
        }
    }
}