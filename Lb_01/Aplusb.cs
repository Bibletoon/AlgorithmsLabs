using System;
using System.IO;

namespace AlgorithmsLabs.First
{
    class Aplusb
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllText("aplusb.in").Split();
            int res = Int32.Parse(input[0]) + Int32.Parse(input[1]);
            File.WriteAllText("aplusb.out", res.ToString());
        }
    }
}