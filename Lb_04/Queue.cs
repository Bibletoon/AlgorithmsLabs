using System;
using System.IO;

namespace AlgorithmsLabs.Fourth
{ 
    class Queue
    {
        private int head;
        private int tail;
        private int[] array;

        public Queue(int maxSize)
        {
            array = new int[maxSize];
            head = 0;
            tail = 0;
        }

        public void Push(int element)
        {
            array[tail] = element;
            tail = (tail + 1) % array.Length;
        }

        public int Pop()
        {
            int res = array[head];
            head = (head + 1) % array.Length;
            return res;
        }
    }

    class QueueComands
    {
        static void Main(string[] args)
        {
            StreamReader inputFile = new StreamReader("queue.in");
            StreamWriter outputFile = new StreamWriter("queue.out");
            int n = Int32.Parse(inputFile.ReadLine());
            Queue myQueue = new Queue(1000_000);
            string[] command;
            for (int i = 0; i < n; i++)
            {
                command = inputFile.ReadLine().Split();
                if (command[0] == "+")
                {
                    myQueue.Push(Int32.Parse(command[1]));
                } else
                {
                    outputFile.WriteLine(myQueue.Pop());
                }
            }
            inputFile.Close();
            outputFile.Close();
        }
    }
}