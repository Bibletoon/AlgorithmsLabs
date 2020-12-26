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

        public int? PopOrNull()
        {
            if (index==-1)
            {
                return null;
            }
            int result = array[index];
            index -= 1;
            return result;
        }

        public int GetLen()
        {
            return index + 1;
        }
    }

    class Brackets
    {
        static void Main(string[] args)
        {
            StreamReader inputFile = new StreamReader("brackets.in");
            StreamWriter outputFile = new StreamWriter("brackets.out");
            string input;

            while ((input = inputFile.ReadLine()) != null && input != "")
            {
                Stack myStack = new Stack(10_000);
                bool end = false;
                int? id;
                foreach (char i in input)
                {
                    switch (i)
                    {
                        case '(':
                            myStack.Push(1);
                            break;
                        case '[':
                            myStack.Push(2);
                            break;
                        case ')':
                            id = myStack.PopOrNull();
                            if (id != 1)
                            {
                                end = true;
                            }
                            break;
                        case ']':
                            id = myStack.PopOrNull();
                            if (id != 2)
                            {
                                end = true;
                            }
                            break;
                    }
                    if (end)
                    {
                        break;
                    }
                }
                if (end || myStack.GetLen() != 0)
                {
                    outputFile.WriteLine("NO");
                }
                else
                {
                    outputFile.WriteLine("YES");
                }
            }
            inputFile.Close();
            outputFile.Close();
        }
    }
}