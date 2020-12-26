using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmsLabs.Fifth
{
    class Set
    {
        private List<long>[] table;

        public Set()
        {
            table = new List<long>[1000000];
        }

        private int getHashCode(long val)
        {
            return (int)(Math.Abs(val) % 1000000);
        }

        public void Insert(long val)
        {
            int code = getHashCode(val);
            if (table[code] == null)
            {
                table[code] = new List<long>();
                table[code].Add(val);
            } else if (!table[code].Contains(val))
            {
                table[code].Add(val);
            }
        }

        public void Delete(long val)
        {
            int code = getHashCode(val);
            if (table[code] != null)
            {
                table[code].Remove(val);
            }
        }

        public bool Exists(long val)
        {
            int code = getHashCode(val);
            return table[code]?.Contains(val) ?? false;
        }

    }

    class SetCommands
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("set.in");
            var outputFile = new StreamWriter("set.out");
            string command;
            Set mySet = new Set();
            while ((command=inputFile.ReadLine())!="" && command!=null)
            {
                string[] request = command.Split();
                switch (request[0])
                {
                    case "insert":
                        mySet.Insert(long.Parse(request[1]));
                        break;
                    case "delete":
                        mySet.Delete(long.Parse(request[1]));
                        break;
                    case "exists":
                        outputFile.WriteLine(mySet.Exists(long.Parse(request[1])) ? "true" : "false");
                        break;

                }
            }

            inputFile.Close();
            outputFile.Close();
        }
    }
}