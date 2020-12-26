using System;
using System.IO;
using System.Linq;
using System.Globalization;

namespace AlgorithmsLabs.First
{
    class Sortland
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("sortland.in");
            int n = Int32.Parse(input[0]);
            float[][] arr = new float[n][];
            string[] line = input[1].Split();
            for (int i = 0; i < n; i++)
            {
                arr[i] = new float[2] { float.Parse(line[i],CultureInfo.InvariantCulture), i + 1 };
            }
            arr = arr.OrderBy(s => s[0]).ToArray();
            string res = arr[0][1].ToString() + " " + arr[n/2][1].ToString() + " " + arr[n - 1][1];
            File.WriteAllText("sortland.out", res);

        }
    }
}