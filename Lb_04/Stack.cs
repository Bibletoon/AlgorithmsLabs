using System;
using System.IO;


namespace AlgorithmsLabs.Fourth
{
    class Stack
    {
        int index;
        int[] array;

        public Stack(int maxSize)
        {
            array = new int[maxSize];
            index = -1;
        }

        public void Push(int element)
        {
            index += 1;
            array[index] = element;
        }

        public int Pop()
        {
            int result = array[index];
            index -= 1;
            return result;
        }
    }

    class StackComands
    {
        static void Main(string[] args)
        {
            StreamReader inputFile = new StreamReader("stack.in");
            StreamWriter outputFile = new StreamWriter("stack.out");
            int n = Int32.Parse(inputFile.ReadLine());
            Stack myStack = new Stack(1000_000);
            string[] command;
            for (int i = 0; i < n; i++)
            {
                command = inputFile.ReadLine().Split();
                if (command[0] == "+")
                {
                    myStack.Push(Int32.Parse(command[1]));
                }
                else
                {
                    outputFile.WriteLine(myStack.Pop());
                }
            }
            inputFile.Close();
            outputFile.Close();
        }
    }
}