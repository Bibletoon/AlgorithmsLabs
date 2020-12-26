using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmsLabs.Fifth
{
    class Map
    {
        private List<(string, string)>[] table;

        public Map()
        {
            table = new List<(string, string)>[501];
        }

        private int getHashCode(string val)
        {
            int code = 0;
            foreach (char c in val.ToLower())
            {
                code += (int) c - 97;
            }

            return code;
        }

        public void Put(string key, string val)
        {
            int code = getHashCode(key);

            if (table[code] == null)
            {
                table[code] = new List<(string, string)>();
                table[code].Add((key,val));
            }
            else
            {
                table[code].RemoveAll(x => x.Item1 == key);
                table[code].Add((key,val));
            }
        }

        public void Delete(string key)
        {
            int code = getHashCode(key);

            if (table[code]!=null)
            {
                table[code].RemoveAll(x => x.Item1 == key);
            }
        }

        public string Get(string key)
        {
            int code = getHashCode(key);

            if (table[code] != null && table[code].Exists(x => x.Item1 == key))
            {
                return table[code].Find(x => x.Item1 == key).Item2;
            }

            return "none";
        }
    }

    class MapCommands
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("map.in");
            var outputFile = new StreamWriter("map.out");
            string command;
            var myMap = new Map();
            while ((command=inputFile.ReadLine())!="" && command!=null)
            {
                string[] request = command.Split();
                switch (request[0])
                {
                    case "put":
                        myMap.Put(request[1],request[2]);
                        break;
                    case "delete":
                        myMap.Delete(request[1]);
                        break;
                    case "get":
                        outputFile.WriteLine(myMap.Get(request[1]));
                        break;

                }
            }

            inputFile.Close();
            outputFile.Close();
        }
    }
}