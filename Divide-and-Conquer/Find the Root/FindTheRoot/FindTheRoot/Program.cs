using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace FindTheRoot
{
    class Program
    {

        #region I/O
        static void Main(string[] args)
        {
            int nCases;
            double result, actualResult;
            StreamReader sr;
            TextReader origConsole = Console.In;
            Console.WriteLine("Find The Root Problem:\n[1] Sample test cases\n[2] Complete testing");
            Console.Write("\nEnter your choice [1-2]: ");
            char choice = (char)Console.ReadLine()[0];
            switch (choice)
            {
                case '1':
                        sr = new StreamReader("samples.txt");
                        Console.SetIn(sr);

                        nCases = int.Parse(Console.ReadLine());

                        for (int i = 0; i < nCases; i++)
                        {
                            string[] lineItems = Console.ReadLine().Split(' ');
                            int p = int.Parse(lineItems[0]);
                            int q = int.Parse(lineItems[1]);
                            int r = int.Parse(lineItems[2]);
                            int s = int.Parse(lineItems[3]);
                            int t = int.Parse(lineItems[4]);
                            int u = int.Parse(lineItems[5]);

                            Console.WriteLine("Case " + (i + 1).ToString() + ":");
                            Console.WriteLine("p = " + p + ", q = " + q + ", r = " + r + ", s = " + s + ", t = " + t + ", u = " + u);

                            long timeBefore = System.Environment.TickCount;
                            result = Math.Round(FindTheRoot.findTheRoot(p, q, r, s, t, u), 4);
                            long timeAfter = System.Environment.TickCount;
                            if (timeAfter - timeBefore > 110)
                            {
                                Console.WriteLine("Time limit exceed: case # " + (i + 1));
                                sr.Close();
                                return;
                            }
                            actualResult = double.Parse(Console.ReadLine());
                            if (actualResult != result)
                            {
                                Console.WriteLine("Wrong Answer!" + " your answer = "
                                    + result + ", correct answer = " + actualResult);
                                sr.Close();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Succeed");
                            }
                        }
                        sr.Close();

                        Console.SetIn(origConsole);

                        Console.WriteLine("Sample cases run successfully. you should run Complete Testing... ");
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
                        Console.WriteLine("\nComplete Testing is running now...");
                        sr = new StreamReader("input.txt");
                        Console.SetIn(sr);
                   
                        nCases = int.Parse(Console.ReadLine());

                        for (int i = 0; i < nCases; i++)
                        {
                            string[] lineItems = Console.ReadLine().Split(' ');
                            int p = int.Parse(lineItems[0]);
                            int q = int.Parse(lineItems[1]);
                            int r = int.Parse(lineItems[2]);
                            int s = int.Parse(lineItems[3]);
                            int t = int.Parse(lineItems[4]);
                            int u = int.Parse(lineItems[5]);

                            long timeBefore = System.Environment.TickCount;
                            result = Math.Round(FindTheRoot.findTheRoot(p, q, r, s, t, u), 4); 
                            long timeAfter = System.Environment.TickCount;
                            if (timeAfter - timeBefore > 100)
                            {
                                Console.WriteLine("Time limit exceed: case # " + (i + 1));
                                sr.Close();
                                return;
                            }
                            actualResult = double.Parse(Console.ReadLine());
                                if (actualResult != result)
                            {
                                Console.WriteLine("Wrong Answer: case # " + (i + 1) + ": your answer = "
                                    + result + ", correct answer = " + actualResult);
                                sr.Close();
                                return;
                            }
                        }
                        sr.Close();
                        Console.WriteLine("\nCongratulations... your program runs successfully");
                        break;
                    
            }
        }
        #endregion
        
    }
}
