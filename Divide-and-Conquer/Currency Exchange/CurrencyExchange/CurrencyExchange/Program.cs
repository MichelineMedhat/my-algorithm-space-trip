using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CurrencyExchange
{
	class Program
	{
 
        #region I/O
        static void Main(string[] args)
        {
            Console.WriteLine("Currency Exchange Problem:\n[1] Sample test cases\n[2] Complete testing");
            Console.Write("\nEnter your choice [1-2]: ");
            char choice = (char)Console.ReadLine()[0];
            switch (choice)
            {
                case '1':
                    bool succeed = ReadAndCheck("sample.txt", 50);

                    if (succeed)
                    {
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
                    }
                    else
                    {
                        return;
                    }


                case '2':
                CompleteTest:
                    Console.WriteLine("Complete Testing is running now...");
                    succeed = ReadAndCheck("inout.txt", 40);
                    if (succeed)
                    {
                        Console.WriteLine("\nCongratulations... your program runs successfully");
                    }
                    break;
            }
        }


        static bool ReadAndCheck(string fileName, int timeLimit)
		{
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader(file);
			int cases = int.Parse(sr.ReadLine());
			int wrongAnswer = 0;
			for (int a = 0; a < cases; a++)
			{
				string[] twoParts = sr.ReadLine().Split(' ');
				int nCustomers = int.Parse(twoParts[0]);
				int nCurrency = int.Parse(twoParts[1]);
				bool[,] knows = new bool[nCustomers,nCurrency];
				for (int i = 0; i < nCustomers; i++)
				{
					string line = sr.ReadLine();
					for (int j = 0; j < nCurrency; j++)
					{
						if (line[j] == 'Y')
							knows[i, j] = true;
						else
							knows[i, j] = false;
					}
				}
                long timeBefore = System.Environment.TickCount;        
				for (int i = 0; i < 4000; i++)
				{
                    CurrencyExchange.CheckUSD(nCustomers, nCurrency, knows);
				}
                long timeAfter = System.Environment.TickCount;
                if (timeAfter - timeBefore > timeLimit)
                {
                    Console.WriteLine("Time limit exceed: case # " + (a + 1));
                    sr.Close();
                    return false;
                }
                
				int expectedResult = int.Parse(sr.ReadLine());
                int receivedResult = CurrencyExchange.CheckUSD(nCustomers, nCurrency, knows);
				if (receivedResult != expectedResult)
				{
					wrongAnswer++;
					Console.WriteLine("wrong answer at case " + (a + 1) + " expected = " + expectedResult + " received = " + receivedResult);
				}
			}
            sr.Close();
            file.Close();
            if (wrongAnswer == 0)
            {
                Console.WriteLine("Congratulations... :)");
                return true;
            }
            else
            {
                Console.WriteLine(wrongAnswer + " wrong answer out of " + cases + " case with percent " + (cases - (double)wrongAnswer) * 100 / cases + "% correct");
                return false;
            }
		}	
        #endregion

    }
}

