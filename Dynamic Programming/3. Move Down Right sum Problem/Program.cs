namespace _3.Move_Down_Right_sum_Problem
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[,]
            {
                {2, 6, 1, 8, 9, 4, 2},
                {1, 8, 0, 3, 5, 6, 7},
                {3, 4, 8, 7, 2, 1, 8},
                {0, 9, 2, 8, 1, 7, 9},
                {2, 7, 1, 9, 7, 8, 2},
                {4, 5, 6, 1, 2, 5, 6},
                {9, 3, 5, 2, 8, 1, 9},
                {2, 3, 4, 1, 7, 2, 8}
            };

            var sums = new int[8, 7];

            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    var current = arr[row, col];
                    var left = col != 0 ? sums[row, col - 1] : 0;
                    var top = row != 0 ? sums[row - 1, col] : 0;

                    sums[row, col] = Math.Max(left, top) + current;
                }
            }

            Console.WriteLine(sums[7, 6]);
        }
    }
}
