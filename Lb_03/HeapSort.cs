using System;
using System.IO;
using System.Linq;

namespace AlgorithmsLabs.Third
{
    class Heap
    {
        public long[] heap;
        public int heapSize;

        public Heap(long[] array)
        {
            heapSize = array.Length;
            heap = new long[heapSize];
            array.CopyTo(heap, 0);
        }

        public void Swap(ref long a, ref long b)
        {
            long temp = a;
            a = b;
            b = temp;
        }

        public void BuildMaxHeap()
        {
            for (int i=heapSize/2;i>=0;i--)
            {
                MaxHeapify(i);
            }
        }

        public void MaxHeapify(int index)
        {
            int leftSon = index * 2 + 1;
            int rightSon = index * 2 + 2;
            int largest = index;
            if (leftSon < heapSize && heap[leftSon]>heap[largest])
            {
                largest = leftSon;
            }
            if (rightSon < heapSize && heap[rightSon] > heap[largest])
            {
                largest = rightSon;
            }
            if (index!=largest)
            {
                Swap(ref heap[index], ref heap[largest]);
                MaxHeapify(largest);
            }
        }


    }

    class IsHeap
    {
        static long[] Sort(long[] arr)
        {
            Heap heap = new Heap(arr);
            heap.BuildMaxHeap();
            for (int i=0;i<arr.Length;i++)
            {
                heap.Swap(ref heap.heap[0], ref heap.heap[heap.heapSize - 1]);
                heap.heapSize--;
                heap.MaxHeapify(0);
            }
            return heap.heap;

        }
        static void Main(string[] args)
        {
            StreamReader inputFile = new StreamReader("sort.in");
            int n = Int32.Parse(inputFile.ReadLine());
            string[] rawArr = inputFile.ReadLine().Split();
            inputFile.Close();
            long[] array = new long[n];
            for (int i =0;i<n;i++)
            {
                array[i] = Int64.Parse(rawArr[i]);
            }
            array = Sort(array);
            StreamWriter outputFile = new StreamWriter("sort.out");
            outputFile.WriteLine(String.Join(" ", array));
            outputFile.Close();
        }
    }
}