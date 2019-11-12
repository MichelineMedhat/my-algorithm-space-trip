using System;

namespace Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] weights = new int[] { 7, 3, 4, 5 };
            int[] values = new int[] { 42, 12, 40, 25 };
            int maxWeight = 10;
            int[,] knapsackValues = knapsack(weights, values, maxWeight);
            Console.WriteLine("The max benefit is : " + knapsackValues[values.Length, maxWeight]);

            int[] valuesIndexes = indexes(knapsackValues, maxWeight, weights);
            Console.Write("At indexes : ");
            for (int i = 0; i < valuesIndexes.Length; i++)
            {
                if (valuesIndexes[i] == 0)
                    break;
                Console.Write(valuesIndexes[i] + " ");
            }

            Console.WriteLine();
        }

        // Return maximum between two integers
        static int max(int x, int y)
        {
            return (x > y) ? x : y;
        }

        // Fill the knapsack 2D array
        static int[,] knapsack(int[] weights, int[] values, int maxWeight)
        {

            int n = weights.Length;
            int[,] k = new int[n + 1, maxWeight + 1];

            for (int i = 0; i <= n; i++)
            {

                for (int j = 0; j <= maxWeight; j++)
                {

                    if (i == 0 || j == 0)
                    {
                        k[i, j] = 0;
                    }

                    else if (weights[i - 1] <= j)
                    {
                        k[i, j] = max(k[i, j], values[i - 1] + k[i - 1, j - weights[i - 1]]);
                    }

                    else
                    {
                        k[i, j] = k[i - 1, j];
                    }
                }

            }
            return k;

        }

        // Get the indexes of the items
        static int[] indexes(int[,] k, int maxWeight, int[] weight)
        {

            int w = weight.Length;
            int[] indexes = new int[w];
            int counter = 0;
            for (int i = w; i > 0; i--)
            {
                if (k[i - 1, maxWeight] == 0)
                {
                    break;
                }

                if (k[i, maxWeight] != k[i - 1, maxWeight])
                {
                    indexes[counter] = i;
                    counter++;
                    maxWeight -= weight[i - 1];
                }

            }

            return indexes;


        }
    }
}
