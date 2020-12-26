using System;

namespace AlgorithmsLabs.Fourth
{


    class Garland
    {
        static decimal answer;

        static bool CheckValid(int count, decimal firstHeight, decimal lastHeight)
        {
            decimal first = firstHeight;
            decimal second = lastHeight;
            decimal nw;
            for (int i = 2; i < count; i++)
            {
                nw = 2 * second + 2 - first;
                if (nw < 0)
                {
                    return false;
                }
                first = second;
                second = nw;
            }
            answer = second;
            return true;
        }

        static void FindAnswer(int count, decimal firstHeight)
        {
            decimal l = 0;
            decimal r = firstHeight;
            while (r - l > (decimal)0.019 / (count - 1))
            {
                decimal mid = (r + l) / 2;
                if (CheckValid(count, firstHeight, mid))
                {
                    r = mid;
                }
                else
                {
                    l = mid;
                }
            }
        }

        static void Main(string[] args)
        {
            string[] inp = Console.ReadLine().Split();
            int n = Int32.Parse(inp[0]);
            decimal A = decimal.Parse(inp[1]);
            FindAnswer(n, A);

            Console.WriteLine(Math.Floor(answer).ToString()+"."+(Math.Floor(answer*100)%100).ToString());
        }
    }
}