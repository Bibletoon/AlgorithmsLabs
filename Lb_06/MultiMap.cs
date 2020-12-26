using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmsLabs.Fifth
{
    class LinkedSetItem
    {
        public string Value;
        public LinkedSetItem Prev;
        public LinkedSetItem Next;

        public LinkedSetItem(string value, LinkedSetItem prev, LinkedSetItem next = null)
        {
            Value = value;
            Prev = prev;
            Next = next;
        }
    }

    class LinkedSet
    {
        public LinkedSetItem First;
        private LinkedSetItem last;
        private List<LinkedSetItem>[] table;
        public int Size;
        public string Key;

        public LinkedSet(string key)
        {
            First = null;
            last = null;
            Size = 0;
            table = new List<LinkedSetItem>[107];
            Key = key;
        }

        private int getHashCode(string value)
        {
            Int64 hashCode = 0;
            Int64 helper = 1;
            foreach (var ch in value.ToLower())
            {
                hashCode += (Int64)(ch - 'a') * helper % 107;
                hashCode %= 107;
                helper *= 37;
                helper %= 107;
            }
            return Math.Abs((int)hashCode);
        }

        public void Put(string value)
        {
            int code = getHashCode(value);
            if (table[code] == null)
            {
                table[code] = new List<LinkedSetItem>();
            }

            if (!table[code].Exists(x => x.Value == value))
            {
                var newItem = new LinkedSetItem(value, last);
                table[code].Add(newItem);
                Size++;
                if (First == null)
                {
                    First = newItem;
                }

                if (last != null)
                {
                    last.Next = newItem;
                }
                last = newItem;
                
            }
        }

        public void Delete(string value)
        {
            int code = getHashCode(value);
            if (table[code] == null)
            {
                return;
            }

            if (table[code].Exists(x => x.Value == value))
            {
                LinkedSetItem item = table[code].Find(x=>x.Value==value);
                table[code].Remove(item);
                Size--;
                if (item.Next != null)
                {
                    item.Next.Prev = item.Prev;
                }

                if (item.Prev != null)
                {
                    item.Prev.Next = item.Next;
                }

                if (item.Value == last?.Value)
                {
                    last = item.Prev;
                }

                if (item.Value == First?.Value)
                {
                    First = item.Next;
                }
            }
        }

        public void DeleteAll()
        {
            table = new List<LinkedSetItem>[107];
            First = null;
            last = null;
            Size = 0;
        }
    }

    class MultiMap
    {
        private List<LinkedSet>[] table;

        public MultiMap()
        {
            table = new List<LinkedSet>[107];
        }

        private int getHashCode(string key)
        {
            Int64 hashCode = 0;
            Int64 helper = 1;
            foreach (var ch in key.ToLower())
            {
                hashCode += (Int64)(ch - 'a') * helper % 107;
                hashCode %= 107;
                helper *= 37;
                helper %= 107;
            }
            return Math.Abs((int)hashCode);
        }

        public void Put(string key, string value)
        {
            int code = getHashCode(key);
            if (table[code] == null)
            {
                table[code] = new List<LinkedSet>();
            }

            if (!table[code].Exists(x => x.Key == key))
            {
                table[code].Add(new LinkedSet(key));
            }

            table[code].Find(x => x.Key == key).Put(value);
        }

        public void Delete(string key, string value)
        {
            int code = getHashCode(key);
            if (table[code] == null)
            {
                return;
            }

            if (table[code].Exists(x => x.Key == key))
            {
                table[code].Find(x=>x.Key==key).Delete(value);
            }
        }

        public void DeleteAll(string key)
        {
            int code = getHashCode(key);
            if (table[code] == null)
            {
                return;
            }

            if (table[code].Exists(x => x.Key == key))
            {
                table[code].Find(x => x.Key == key).DeleteAll();
            }
        }

        public LinkedSet Get(string key)
        {
            int code = getHashCode(key);
            if (table[code] == null)
            {
                return null;
            }

            if (table[code].Exists(x => x.Key == key))
            {
                return table[code].Find(x => x.Key == key);
            }

            return null;
        }
    }

    class MultiMapCommands
    {
        static void Main()
        {
            var inputFile = new StreamReader("multimap.in");
            var outputFile = new StreamWriter("multimap.out");
            string command;
            var myMultyMap = new MultiMap();
            while ((command = inputFile.ReadLine()?.Trim()) != "" && command != null)
            {
                string[] request = command.Split();
                switch (request[0])
                {
                    case "put":
                        myMultyMap.Put(request[1], request[2]);
                        break;
                    case "delete":
                        myMultyMap.Delete(request[1],request[2]);
                        break;
                    case "deleteall":
                        myMultyMap.DeleteAll(request[1]);
                        break;
                    case "get":
                        LinkedSet res = myMultyMap.Get(request[1]);
                        if (res == null)
                        {
                            outputFile.WriteLine("0");
                        }
                        else
                        {
                            outputFile.Write(res.Size);
                            LinkedSetItem cur = res.First;
                            while (cur!=null)
                            {
                                outputFile.Write(" ");
                                outputFile.Write(cur.Value);
                                cur = cur.Next;
                            }
                            outputFile.WriteLine();
                        }
                        break;
                }
            }

            inputFile.Close();
            outputFile.Close();
        }
    }
}