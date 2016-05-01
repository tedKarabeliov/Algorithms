namespace _5.Knapsack_problem
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var items = new Tuple<int, int>[] {
                 new Tuple<int, int>(5, 30),
                 new Tuple<int, int>(7, 10),
                 new Tuple<int, int>(8, 120),
                 new Tuple<int, int>(0, 20),
                 new Tuple<int, int>(4, 50),
                 new Tuple<int, int>(5, 80),
                 new Tuple<int, int>(2, 10)
            };

            var targetWeight = 15;

            var possibleSums = new List<Tuple<int, int>>();
            possibleSums.Add(items[0]);

            var possibleSumsToAdd = new List<Tuple<int, int>>();

            for (int i = 1; i < items.Length; i++)
            {
                possibleSumsToAdd.Add(items[i]);

                var currentNum = items[i].Item1;
                var currentWeight = items[i].Item2;

                foreach (var sum in possibleSums)
                {
                    possibleSumsToAdd.Add(new Tuple<int, int>(sum.Item1 + currentNum, sum.Item2 + currentWeight));
                }

                foreach (var item in possibleSumsToAdd)
                {
                    possibleSums.Add(item);
                }

                possibleSumsToAdd.Clear();

                //possibleSums.UnionWith(possibleSumsToAdd);
            }


            var resultWeightsUnderGivenWeight = possibleSums.Where(p => p.Item1 <= targetWeight).ToList();

            var maxItemValue = resultWeightsUnderGivenWeight.Count != 0 ? resultWeightsUnderGivenWeight.Max(p => p.Item2) : 0;

            var result = resultWeightsUnderGivenWeight.FirstOrDefault(p => p.Item2 == maxItemValue);

            if (result != null)
            {
                Console.WriteLine(string.Format("Found: Weight: {0}, Value: {1}", result.Item1, result.Item2));
            }
            else
            {
                Console.WriteLine("No match found");
            }
        }
    }
}
