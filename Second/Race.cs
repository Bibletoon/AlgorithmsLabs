using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgorithmsLabs.Second
{
    class Race
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("race.in");
            int n = Int32.Parse(inputFile.ReadLine());
            Dictionary<string, List<string>> countries = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string[] inp = inputFile.ReadLine().Split();
                if (!countries.ContainsKey(inp[0]))
                {
                    countries.Add(inp[0], new List<string>() { inp[1] });
                }
                else
                {
                    countries[inp[0]].Add(inp[1]);
                }
            }
            inputFile.Close();
            string[] countriesNamesArray = countries.Keys.ToList().ToArray();
            QuickSort(countriesNamesArray, 0, countriesNamesArray.Length - 1);
            using (var outputFile = new StreamWriter("race.out"))
            {
                foreach (string countrie in countriesNamesArray)
                {
                    outputFile.WriteLine($"=== {countrie} ===");
                    outputFile.WriteLine(String.Join("\n", countries[countrie].ToArray()));
                }
            }
        }

        static int Partition(string[] array, int left, int right)
        {
            Random rnd = new Random();
            int number = rnd.Next(left, right);
            string temp = array[number];
            array[number] = array[right];
            array[right] = temp;
            int marker = left;
            for (int i = left; i <= right; i++)
            {
                if (String.CompareOrdinal(array[i], array[right]) <= 0)
                {
                    temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            return marker - 1;
        }

        static void QuickSort(string[] array, int left, int right)
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