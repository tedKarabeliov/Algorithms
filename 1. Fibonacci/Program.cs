namespace _1.Fibonacci
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static IDictionary<int, decimal> fibonacciCache = new Dictionary<int, decimal>();

        public static void Main(string[] args)
        {
            // 1, 1, 2, 3, 5, 8, 13, 21, 34

            var result = Fibonacci(30);

            Console.WriteLine(result);
        }

        public static decimal Fibonacci(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (n == 1)
            {
                return 1;
            }

            if (fibonacciCache.ContainsKey(n))
            {
                return fibonacciCache[n];
            }

            var result = Fibonacci(n - 1) + Fibonacci(n - 2);

            fibonacciCache.Add(n, result);

            return result;
        }
    }
}
