using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    // *****************************************
    // DON"T CHANGE CLASS NAME OR FUNCTION NAME
    // *****************************************
    public static class CurrencyExchange
    {
        //Your Code is Here:
        //==================
        /// <summary>
        /// find the index of the USD Dollar $ with the smallest number of questions.
        /// </summary>
        /// <param name="N">Number of customers (N)</param>
        /// <param name="M">Number of currencies (M)</param>
        /// <param name="knows">N*M Matrix indicating whether customer i knows currency j or not</param>
        /// <returns>index of US Dollar</returns>
        public static int CheckUSD(int N, int M, bool[,] knows)
        {
            //knows[P,C]=true if person P knows currency C and knows[P,C]=false if person P doesn't know Currency C.
            int thisIsTheOne = 0;
            int col = 0;
            int counter = 0;

            while (col < M)
            {

                for (int i = 0; i < N; i++)
                {
                    if (knows[i, col])
                    {
                        counter += 1;
                        if (counter == N)
                        {
                            thisIsTheOne = col;
                            col = M;
                            break;
                        }
                    }

                    else
                    {
                        while (true)
                        {
                            col += 1;
                            if (knows[i, col])
                            {
                                counter = 0;
                                break;
                            }
                            else
                                continue;
                        }
                        break;
                    }
                }

            }
            return thisIsTheOne;
        }
    }
}