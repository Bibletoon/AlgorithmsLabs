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

        public int GetLen()
        {
            return index + 1;
        }
    }

    class Postfix
    {
        static void Main(string[] args)
        {
            StreamReader inputFile = new StreamReader("postfix.in");
            StreamWriter outputFile = new StreamWriter("postfix.out");
            string input = inputFile.ReadLine();
            Stack myStack = new Stack(100);
            int opOne;
            int opTwo;
            foreach (string i in input.Split())
            {
                switch (i)
                {
                    case "+":
                        opTwo = myStack.Pop();
                        opOne = myStack.Pop();
                        myStack.Push(opOne + opTwo);
                        break;
                    case "-":
                        opTwo = myStack.Pop();
                        opOne = myStack.Pop();
                        myStack.Push(opOne - opTwo);
                        break;
                    case "*":
                        opTwo = myStack.Pop();
                        opOne = myStack.Pop();
                        myStack.Push(opOne * opTwo);
                        break;
                    case " ":
                    case "":
                        break;
                    default:
                        myStack.Push(Int32.Parse(i));
                        break;
                }
            }
            outputFile.WriteLine(myStack.Pop());
            inputFile.Close();
            outputFile.Close();
        }
    }
}