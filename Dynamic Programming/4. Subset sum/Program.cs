namespace _4.Subset_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 5, 8, 7, 0, 4, 5, 2 };

            CalculateSums(nums);

            var targetSum = 15;

            CalculateTargetSum(nums, targetSum);
        }

        static void CalculateSums(int[] nums)
        {
            var possibleSums = new HashSet<int>();
            possibleSums.Add(0);

            var possibleSumsToAdd = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var currentNum = nums[i];

                foreach (var sum in possibleSums)
                {
                    possibleSumsToAdd.Add(sum + currentNum);
                }

                possibleSums.UnionWith(possibleSumsToAdd);
            }

            var builder = new StringBuilder();

            foreach (var sum in possibleSums)
            {
                builder.Append(sum + ", ");
            }

            Console.WriteLine(builder.Remove(builder.Length - 2, 2).ToString());
        }

        static void CalculateTargetSum(int[] nums, int targetSum)
        {
            var possibleSums = new Dictionary<int, int>();
            possibleSums.Add(0, 0);

            var possibleSumsToAdd = new Dictionary<int, int>();

            var builder = new StringBuilder();

            for (int i = 0; i < nums.Length; i++)
            {
                var currentNum = nums[i];

                foreach (var sum in possibleSums.Keys)
                {
                    var newSum = sum + currentNum;

                    if (!(possibleSumsToAdd.ContainsKey(newSum)))
                    {
                        possibleSumsToAdd.Add(newSum, sum);
                    }
                }

                foreach (var sum in possibleSumsToAdd)
                {
                    if (!(possibleSums.ContainsKey(sum.Key)))
                    {
                        possibleSums.Add(sum.Key, sum.Value);
                    }
                }

                if (possibleSums.ContainsKey(targetSum))
                {
                    var result = new List<int>();

                    var sum = possibleSums[targetSum]; // [6, 5]

                    while (sum != 0)
                    {
                        result.Add(sum);
                        sum = possibleSums[sum];
                    }

                    var lastSum = targetSum - result.Sum();

                    result.Add(lastSum);

                    builder.Append("Found sum: ");

                    foreach (var number in result)
                    {
                        builder.Append(number + " + ");
                    }

                    builder.Remove(builder.Length - 3, 3);
                    builder.Append(" = " + targetSum);

                    Console.WriteLine(builder);
                    builder.Clear();

                    return;
                }
            }

            Console.WriteLine(builder.Append("No match found !"));
        }

    }
}
