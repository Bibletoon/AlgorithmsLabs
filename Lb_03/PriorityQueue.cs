using System;
 
namespace AlgorithmsLabs.Third
{
    class PriorityQueue
    {
        //Root - queue[0], first son - 2*i+1,second son 2*i+2
        private const int maxSize = 1_000_000;
        public (long, int)[] queue;
        private int queueSize;
 
        public PriorityQueue()
        {
            queueSize = 0;
            queue = new (long, int)[maxSize];
        }
 
        private void Swap<Template>(ref Template a, ref Template b)
        {
            Template temp = a;
            a = b;
            b = temp;
        }
 
        private void ShiftDown(int index)
        {
            while (index * 2 + 1 < queueSize)
            {
                int j = index * 2 + 1;
                if (index * 2 + 2 < queueSize && queue[index * 2 + 2].Item1 < queue[j].Item1)
                {
                    j = index * 2 + 2;
                }
                if (queue[index].Item1 <= queue[j].Item1)
                {
                    break;
                }
                Swap(ref queue[index], ref queue[j]);
                index = j;
            }
        }
 
        private void ShiftUp(int index)
        {
            while (queue[index].Item1 < queue[(index - 1) / 2].Item1)
            {
                Swap(ref queue[index], ref queue[(index - 1) / 2]);
                index = (index - 1) / 2;
            }
        }
 
        private int GetIndex(int id)
        {
            int result = -1;
            for (int i=0;i<queueSize;i++)
            {
                if (queue[i].Item2==id)
                {
                    result = i;
                }
            }
            return result;
        }
 
        public long? GetMinOrNull()
        {
            if (queueSize==0)
            {
                return null;
            }
            long min = queue[0].Item1;
            queue[0] = (0, 0);
            Swap(ref queue[0], ref queue[queueSize-1]);
            queueSize--;
            ShiftDown(0);
            return min;
        }
 
        public void AddItem(long item, int id)
        {
            queue[queueSize] = (item, id);
            ShiftUp(queueSize);
            queueSize++;
        }
 
        public void DecreaseItem(long item, int id)
        {
            int index = GetIndex(id);
            queue[index].Item1 = item;
            ShiftUp(index);
        }
 
    }
 
    class PriorityQueueCommands
    {
        static void Main(string[] args)
        {
            //StreamReader inputFile = new StreamReader("priorityqueue.in");
            //StreamWriter outputFile = new StreamWriter("priorityqueue.out");
            string request;
            string[] commands;
            PriorityQueue myQueue = new PriorityQueue();
            int id=0;
            while ((request = Console.ReadLine())!=null && request!="")
            {
                commands = request.Split();
                id++;
                switch (commands[0])
                {
                    case "push":
                        long item = Int64.Parse(commands[1]);
                        myQueue.AddItem(item, id);
                        break;
                    case "decrease-key":
                        long newItem = Int64.Parse(commands[2]);
                        int idChange = Int32.Parse(commands[1]);
                        myQueue.DecreaseItem(newItem, idChange);
                        break;
                    case "extract-min":
                        var result = myQueue.GetMinOrNull();
                        if (result == null)
                        {
                            Console.WriteLine("* ");
                        }
                        else
                        {
                            Console.WriteLine(result.ToString());
                        }
                        break;
                }
            }
        }
    }
}