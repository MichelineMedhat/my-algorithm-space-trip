using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace AliBaba
{
    class Program
    {
        #region I/O
        static void Main(string[] args)
        {
            int nCases;
            int result, actualResult;
            int[] weights= null;
            int[] profits = null;
            int[] instances = null;
            int itemsCount;
            int W;
            string[] lineItems;
        
            StreamReader sr;
            TextReader origConsole = Console.In;
            Console.WriteLine("Ali Baba in a Cave Problem:\n[1] Sample test cases\n[2] Complete testing");
            Console.Write("\nEnter your choice [1-2]: ");
            char choice = (char)Console.ReadLine()[0];
            switch (choice)
            {
                case '1':
                    sr = new StreamReader("samples.txt");
                    Console.SetIn(sr);
                    bool wrongIndicesFlag = false;
                    nCases = int.Parse(Console.ReadLine());

                    int wrong_bonus_case = -1;
                    for (int i = 0; i < nCases; i++)
                    {
                        bool wrongIndices = false;
                        lineItems = Console.ReadLine().Split(' ');
                        itemsCount = int.Parse(lineItems[0]);
                        W = int.Parse(lineItems[1]);
                        weights = new int[itemsCount + 1];
                        profits = new int[itemsCount + 1];
                        instances = new int[itemsCount + 1];
                        for (int j = 1; j <= itemsCount; j++)
                        {
                            lineItems = Console.ReadLine().Split(' ');
                            weights[j] = int.Parse(lineItems[0]);
                            profits[j] = int.Parse(lineItems[1]);
                            instances[j] = int.Parse(lineItems[2]);
                        }

                        Console.WriteLine("Case " + (i + 1).ToString() + ":");
                        Console.WriteLine("camelsLoad = " + W + ", num of items = " + itemsCount);
                        Console.WriteLine("Weight   Profit  #Instances");
                        Console.WriteLine("=============================");
                        for (int j = 1; j <= itemsCount; j++)
                        {
                            Console.WriteLine(weights[j] + "    " + profits[j] + "    " + instances[j]);
                        }
                        int[] items_taken = new int[itemsCount];
                        int[] instances_of_items_taken = new int[itemsCount];
                        long timeBefore = System.Environment.TickCount;
                        result = AliBaba.AliBabaSol(W, itemsCount, weights, profits, instances, ref items_taken, ref instances_of_items_taken);
                        long timeAfter = System.Environment.TickCount;
                        if (timeAfter - timeBefore > 100)
                        {
                            Console.WriteLine("Time limit exceed: case # " + (i + 1));
                            sr.Close();
                            return;
                        }
                        actualResult = int.Parse(Console.ReadLine());


                        if (actualResult != result)
                        {
                            Console.WriteLine("Wrong Answer: case # " + i + 1 + ": your answer = "
                                + result + ", correct answer = " + actualResult);
                            sr.Close();
                            return;
                        }
                        else
                        {
                            string items_line = Console.ReadLine();
                            string[] actualSelectedItems = items_line.Split(' ');
                            string[] actualInstances = Console.ReadLine().Split(' ');
                            if (items_line == "" && items_taken[0] != 0)
                            {
                                wrongIndices = true;
                            }
                            else if (items_line == "")
                            {
                                for(int xx = 0; xx < itemsCount; xx++)
                                    if(items_taken[xx] !=0)
                                        wrongIndices = true;
                            }
                            else
                            {
                                int lastMatchIndex = -1;
                                for (int k = 0; k < actualSelectedItems.Length; k++)
                                {
                                    if (int.Parse(actualSelectedItems[k]) != items_taken[k])
                                    {
                                        lastMatchIndex = k;
                                        break;
                                    }
                                }
                                if (lastMatchIndex != -1)
                                {
                                    //Check sum of the selected items
                                    long sum = 0;
                                    for (int k = 0; k < items_taken.Length; k++)
                                    {
                                        if (items_taken[k] <= 0 || items_taken[k] > W || instances[items_taken[k]] < instances_of_items_taken[k])
                                            continue;
                                        sum += profits[items_taken[k]] * instances_of_items_taken[k];
                                    }
                                    if (sum != actualResult)
                                    {
                                        wrongIndices = true;
                                    }
                                }
                            }
                            Console.WriteLine("Main: Succeed");
                            if (wrongIndices)
                            {
                                if (wrongIndicesFlag == false)
                                {
                                    wrong_bonus_case = i + 1;
                                }
                                wrongIndicesFlag = true;
                                Console.WriteLine("BONUS: FAILED");
                            }
                            else
                                Console.WriteLine("BONUS: Succeed");
                        }

                        Debug.Assert(Console.ReadLine().Trim() == string.Empty);
                        Debug.Assert(Console.ReadLine().Trim() == string.Empty);
                        Debug.Assert(Console.ReadLine().Trim() == string.Empty);
                        Console.WriteLine("########");
                    }
                    sr.Close();
                    Console.SetIn(origConsole);
                    Console.WriteLine("\n\n[MAIN] CONGRATULATIONS .. Sample cases run successfully. you should run Complete Testing...");
                    if (wrongIndicesFlag)
                    {
                        Console.WriteLine("[BONUS] WRONG ANSWER in case: " + wrong_bonus_case + "...");
                    }
                    else
                    {
                        Console.WriteLine("[BONUS] CONGRATULATIONS .. Sample cases run successfully. you should run Complete Testing... ");
                    }

                    Console.Write("Do you want to run Complete Testing now (y/n)? ");
                    choice = (char)Console.Read();
                    if (choice == 'n' || choice == 'N')
                        break;
                    else if (choice == 'y' || choice == 'Y')
                        goto CompleteTest;
                    else
                    {
                        Console.WriteLine("Invalid Choice!");
                        break;
                    }

                case '2':
                CompleteTest:
                    Console.WriteLine("Complete Testing is running now...");
                    sr = new StreamReader("input.txt");
                    Console.SetIn(sr);
                    wrongIndicesFlag = false;

                    long totalTime = 0;
                    nCases = int.Parse(Console.ReadLine());
                    bool timeLimitExceed = false;
                    wrong_bonus_case = -1;
                    for (int i = 0; i < nCases; i++)
                    {
                        bool wrongIndices = false;
                        lineItems = Console.ReadLine().Split(' ');
                        itemsCount = int.Parse(lineItems[0]);
                        W = int.Parse(lineItems[1]);
                        weights = new int[itemsCount + 1];
                        profits = new int[itemsCount + 1];
                        instances = new int[itemsCount + 1];
                        for (int j = 1; j <= itemsCount; j++)
                        {
                            lineItems = Console.ReadLine().Split(' ');
                            weights[j] = int.Parse(lineItems[0]);
                            profits[j] = int.Parse(lineItems[1]);
                            instances[j] = int.Parse(lineItems[2]);
                        }

                        Console.Write("Case " + (i + 1).ToString() + ": ");

                        int[] items_taken = new int[itemsCount];
                        int[] instances_of_items_taken = new int[itemsCount];
                        Stopwatch sw = Stopwatch.StartNew();
                        result = AliBaba.AliBabaSol(W, itemsCount, weights, profits, instances, ref items_taken, ref instances_of_items_taken);
                        sw.Stop();
                        actualResult = int.Parse(Console.ReadLine());
                        totalTime += sw.ElapsedMilliseconds;
                        if (actualResult != result)
                        {
                            Console.WriteLine("Wrong Answer! your answer = "
                                + result + ", correct answer = " + actualResult);
                            sr.Close();
                            return;
                        }
                        else if (sw.ElapsedMilliseconds > 1200)
                        {
                            Console.WriteLine("Time limit exceed");
                            timeLimitExceed = true;
                            return;
                        }
                        else
                        {
                            string items_line = Console.ReadLine();
                            string[] actualSelectedItems = items_line.Split(' ');
                            string[] actualInstances = Console.ReadLine().Split(' ');
                            if (items_line == "" && items_taken[0] != 0)
                            {
                                wrongIndices = true;
                            }
                            else if (items_line == "")
                            {
                                for (int xx = 0; xx < itemsCount; xx++)
                                    if (items_taken[xx] != 0)
                                        wrongIndices = true;
                            }
                            else
                            {
                                int lastMatchIndex = -1;
                                for (int k = 0; k < actualSelectedItems.Length; k++)
                                {
                                    if (int.Parse(actualSelectedItems[k]) != items_taken[k])
                                    {
                                        lastMatchIndex = k;
                                        break;
                                    }
                                }
                                if (lastMatchIndex != -1)
                                {
                                    //Check sum of the selected items
                                    long sum = 0;
                                    for (int k = 0; k < items_taken.Length; k++)
                                    {
                                        if (items_taken[k] <= 0 || items_taken[k] > W || instances[items_taken[k]] < instances_of_items_taken[k])
                                            continue;
                                        sum += profits[items_taken[k]] * instances_of_items_taken[k];
                                    }
                                    if (sum != actualResult)
                                    {
                                        wrongIndices = true;
                                    }
                                }
                            }
                            Console.WriteLine("\nMain: Succeed");
                            if (wrongIndices)
                            {
                                if (wrongIndicesFlag == false)
                                {
                                    wrong_bonus_case = i + 1;
                                }
                                wrongIndicesFlag = true;
                                Console.WriteLine("BONUS: FAILED");
                            }
                            else
                                Console.WriteLine("BONUS: Succeed");
                        }
                        Debug.Assert(Console.ReadLine().Trim() == string.Empty);
                        Debug.Assert(Console.ReadLine().Trim() == string.Empty);
                        Debug.Assert(Console.ReadLine().Trim() == string.Empty);
                    }
                    sr.Close();
                    Console.SetIn(origConsole);
                    Console.WriteLine("Average time over " + nCases.ToString() + " = " + Math.Round((double)totalTime / nCases, 2).ToString() + " ms");
                    if (timeLimitExceed)
                        Console.WriteLine("Time Limit Exceed");
                    else
                    {
                        Console.WriteLine("\n\n[MAIN] CONGRATULATIONS .. COMPLETE cases run successfully.");
                        if (wrongIndicesFlag)
                        {
                            Console.WriteLine("[BONUS] WRONG ANSWER in case: " + wrong_bonus_case + "...");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("[BONUS] CONGRATULATIONS .. COMPLETER cases run successfully.");
                        }
                    }
                    break;
            }
                    
                         
        }
        #endregion
    }
}
