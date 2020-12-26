using System;
using System.IO;

namespace AlgorithmsLabs.First
{
    class Aplusbb
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllText("aplusbb.in").Split();
            long b = Int32.Parse(input[1]);
            long res = Int32.Parse(input[0]) + (b * b);
            File.WriteAllText("aplusbb.out", res.ToString());
        }
    }
}