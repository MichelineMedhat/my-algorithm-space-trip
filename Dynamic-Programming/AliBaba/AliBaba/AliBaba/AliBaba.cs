using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliBaba
{
    public class AliBaba
    {
        //Your Code is Here:
        //==================
        /// <summary>
        /// Calculate the max total profit that can be carried within the given camels' load
        /// </summary>
        /// <param name="camelsLoad">max load that can be carried by camels</param>
        /// <param name="itemsCount">number of items</param>
        /// <param name="weights">weight of each item [ONE-BASED items]</param>
        /// <param name="profits">profit of each item [ONE-BASED items]</param>
        /// <param name="instances">number of instances for each item [ONE-BASED items]</param>
        /// <param name="items_taken">Empty items of length = itemsCount, to fill it with the indecies of the items selected</param>
        /// <param name="instances_of_items_taken">Empty items of length = itemsCount, to fill it with the instances taken from each selected item</param>
        /// <returns>Max total profit</returns>
        public static int AliBabaSol(int camelsLoad, int itemsCount, int[] weights, int[] profits, int[] instances, ref int[] items_taken, ref int[] instances_of_items_taken)
        {
            int[,] items = new int[profits.Length + 1, camelsLoad + 1];
            for (int i = 1; i < profits.Length; i++) {
                for (int j = 1; j <= camelsLoad; j++) {

                    if (weights[i] > j)
                    {
                        items[i, j] = items[i - 1, j];

                    }
                    else
                    {
                        int max = items[i - 1, j];
                        for (int k = 0; k <= instances[i]; k++)
                        {

                            if (j < weights[i] * k)
                            {
                                break;
                            }
                            else
                            {
                                if (items[i - 1, j - (weights[i] * k)] + profits[i] * k > max)
                                {

                                    max = items[i - 1, j - (weights[i] * k)] + profits[i] * k;
                                }

                            }
                        }
                        items[i, j] = max;
                    }

                }

            }


            int counterItem = 0;
            int indexCounter = 0;
            int[] indexesArr = indexes(items, camelsLoad, weights, instances, profits);
            for (int m = 0; m < indexesArr.Length/2; m++) {
                items_taken[counterItem] = indexesArr[m];
                counterItem++;
            }
 

            for (int m = indexesArr.Length / 2; m < indexesArr.Length; m++)
            {
                instances_of_items_taken[indexCounter] = indexesArr[m];
                indexCounter++;
            }

            return items[profits.Length - 1, camelsLoad];
        }

        static int[] indexes(int[,] k, int maxWeight, int[] weight, int[] instances, int[] profits)
        {

            int w = weight.Length-1;
            int[] indexes = new int[w];
            int[] inst = new int[w];
            int counter = 0;


            while (k[w,maxWeight]!=0)
            {
                if (k[w, maxWeight] != k[w - 1, maxWeight])
                {
                    indexes[counter] = w;
   
                    for (int i = 1; i <= instances[w]; i++)
                    {
                        if (k[w, maxWeight] == i * profits[w] + k[w - 1, maxWeight - (i * weight[w])])
                        {
                            maxWeight -= weight[w]*i;
                            inst[counter] = i;
                            w -= 1;
                            break;
                        }
                    }

                    counter++;


                }
                else
                {
                    w -= 1;
                }
            }


            int indexCounter = 0;
            int instCounter = 0;
            int[] final = new int[counter*2];
            for (int i = 0; i < counter*2; i++)
            {
                if (i < counter)
                {
                    final[i] = indexes[indexCounter];
                    indexCounter++;
                }
                else
                {
                    final[i] = inst[instCounter];
                    instCounter++;
                }
            }

            return final;


        }
    }
}
