using System;
using System.Collections.Generic;
using System.IO;
 
namespace AlgorithmsLabs.Fifth
{
    class LinkedMap
    {
        public class LinkedMapItem
        {
            public string Key;
            public string Value;
            public LinkedMapItem Prev;
            public LinkedMapItem Next;
        }
         
        private List<LinkedMapItem>[] table;
        private LinkedMapItem[] last; //Dikiy kostil
 
        public LinkedMap()
        {
            table = new List<LinkedMapItem>[501];
            last = new LinkedMapItem[1];
            last[0] = null;
        }
 
        private int getHashCode(string val)
        {
            int code = 0;
            foreach (char c in val.ToLower())
            {
                code += (int)c - 97;
            }
 
            return code;
        }
 
        public void Put(string key, string value)
        {
            int code = getHashCode(key);
            if (table[code] == null)
            {
                table[code] = new List<LinkedMapItem>();
            }
 
            if (table[code].Exists(x => x.Key == key))
            {
                table[code].Find(x => x.Key == key).Value = value;
                return;
            }
            LinkedMapItem newItem = new LinkedMapItem();
            newItem.Key = key;
            newItem.Value = value;
            newItem.Prev = last[0];
            if (last[0] != null)
            {
                last[0].Next = newItem;
            }
            last[0] = newItem;
            table[code].Add(newItem);
        }
 
        public void Delete(string key)
        {
            int code = getHashCode(key);
            if (table[code] == null)
            {
                return;
            }
            LinkedMapItem item = table[code].Find(x=>x.Key==key);
 
            if (item == null)
            {
                return;
            }
 
            if (item.Next != null)
            {
                item.Next.Prev = item.Prev;
            }
 
            if (item.Key == last[0].Key)
            {
                last[0] = item.Prev;
            }
 
            if (item.Prev != null)
            {
                item.Prev.Next = item.Next;
            }
 
            table[code].RemoveAll(x=>x.Key==key);
 
        }
 
        public string Get(string key)
        {
            int code = getHashCode(key);
            if (table[code] == null)
            {
                return "none";
            }
 
            return table[code].Find(x => x.Key == key)?.Value ?? "none";
        }
 
        public string Prev(string key)
        {
            int code = getHashCode(key);
            if (table[code] == null)
            {
                return "none";
            }
 
            return table[code].Find(x => x.Key == key)?.Prev?.Value ?? "none";
        }
 
        public string Next(string key)
        {
            int code = getHashCode(key);
            if (table[code] == null)
            {
                return "none";
            }
 
            return table[code].Find(x => x.Key == key)?.Next?.Value ?? "none";
        }
    }
 
    class MapCommands
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("linkedmap.in");
            var outputFile = new StreamWriter("linkedmap.out");
            string command;
            var myLinkedMap = new LinkedMap();
            while ((command=inputFile.ReadLine())!="" && command!=null)
            {
                string[] request = command.Split();
                switch (request[0])
                {
                    case "put":
                        myLinkedMap.Put(request[1],request[2]);
                        break;
                    case "delete":
                        myLinkedMap.Delete(request[1]);
                        break;
                    case "get":
                        outputFile.WriteLine(myLinkedMap.Get(request[1]));
                        break;
                    case "prev":
                        outputFile.WriteLine(myLinkedMap.Prev(request[1]));
                        break;
                    case "next":
                        outputFile.WriteLine(myLinkedMap.Next(request[1]));
                        break;
                }
            }
 
            inputFile.Close();
            outputFile.Close();
        }
    }
}