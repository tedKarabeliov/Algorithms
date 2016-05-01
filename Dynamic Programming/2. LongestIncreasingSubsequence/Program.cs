using System;
using System.Collections.Generic;
namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 7, 3, 5, 8, -1, 6, 7 };
            var sequenceCounter = new int[arr.Length];
            var previousCounter = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                GenerateLISSolution(arr, sequenceCounter, previousCounter, i);
            }

            PrintLISSSolution(arr, sequenceCounter, previousCounter);
        }

        static void GenerateLISSolution(int[] arr, int[] sequenceCounter, int[] previousCounter, int i)
        {
            if (i == 0)
            {
                sequenceCounter[i] = 1;
                previousCounter[i] = -1;
            }

            var maxSequence = 0;
            var maxSequenceIndex = -1;

            for (int k = 0; k < i; k++)
            {
                if (arr[k] < arr[i])
                {
                    if (arr[k] < arr[i])
                    {
                        if (sequenceCounter[k] > maxSequence)
                        {
                            maxSequence = sequenceCounter[k];
                            maxSequenceIndex = k;
                        }
                    }
                }
            }

            if (maxSequenceIndex == -1)
            {
                sequenceCounter[i] = 1;
                previousCounter[i] = -1;
            }
            else
            {
                previousCounter[i] = maxSequenceIndex;
                sequenceCounter[i] = sequenceCounter[maxSequenceIndex] + 1;
            }
        }

        static void PrintLISSSolution(int[] arr, int[] sequenceCounter, int[] previousCounter)
        {
            var result = new List<int>();

            var maxSequenceValue = 0;
            var maxSequenceIndex = -1;

            for (int i = 0; i < sequenceCounter.Length; i++)
            {
                if (sequenceCounter[i] > maxSequenceValue)
                {
                    maxSequenceValue = sequenceCounter[i];
                    maxSequenceIndex = i;
                }
            }

            while (previousCounter[maxSequenceIndex] != -1)
            {
                result.Add(arr[maxSequenceIndex]);
                maxSequenceIndex = previousCounter[maxSequenceIndex];
            }

            result.Add(arr[maxSequenceIndex]);

            for (int i = result.Count - 1; i >= 0; i--)
            {
                Console.Write(result[i]);

                if (i > 0)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine();
        }
    }
}
