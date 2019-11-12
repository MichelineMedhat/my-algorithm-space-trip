using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindTheRoot
{
    class FindTheRoot
    {
        //========================================================================================================
        //GIVEN CODE:
        //===========
        // Calculate the function at a given x (i.e. f(x))
        static double f(int p, int q, int r, int s, int t, int u, double x)
        {
            return p * Math.Exp(-x) + q * Math.Sin(x) + r * Math.Cos(x) + s * Math.Tan(x) + t * x * x + u;
        }

        // "eps" a very small value
        const double eps = 1e-9;


        //========================================================================================================
        //YOUR CODE IS HERE:
        //==================
        // Write efficient algorithm to get the value of x that makes the function f(x) = 0 
        // Return -1 if x is not exists
        // HINT: you can consider that the root (x) is found if the function value f(x) is: -eps < F(x) < eps


        /// <summary>
        /// Write efficient algorithm to get the equation's root (if any) of function f
        /// </summary>
        /// <param name="p"> int between [0, 20] </param>
        /// <param name="q"> int between [-20, 0] </param>
        /// <param name="r"> int between [0, 20] </param>
        /// <param name="s"> int between [-20, 0]</param>
        /// <param name="t"> int between [-20, 0]</param>
        /// <param name="u"> int between [0, 20] </param>
        /// <returns>value of x if exists. Else, return -1</returns>
        public static double findTheRoot(int p, int q, int r, int s, int t, int u)
        {
            //Write your code HERE
            return binarySearch(p, q, r, s, t, u, 0, 1);
        }

        static double binarySearch(int p, int q, int r, int s, int t, int u, double start, double end)
        {
            double mid = (double)(start + end) / 2;

            double fx = f(p, q, r, s, t, u, mid);
            if (fx > -eps && fx < eps)
            {
                return mid;
            }
            if (mid == start || mid == end)
            {
                return -1;
            }
            else if (fx < eps)
            {
                return binarySearch(p, q, r, s, t, u, start, mid);
            }
            else
            {
                return binarySearch(p, q, r, s, t, u, mid, end);
            }
        }




        //========================================================================================================

        #region Sorting function - if you need it
        static void Sorting(int[] collection, int N)
        {
            QSort(0, N - 1, collection, N);
        }

        static void Swap(int i, int j, int[] collection)
        {
            int tmp = collection[i];
            collection[i] = collection[j];
            collection[j] = tmp;
        }

        static void QSort(int startIndex, int finalIndex, int[] collection, int N)
        {
            if (startIndex >= finalIndex) return;
            int i = startIndex, j = finalIndex;
            while (i <= j)
            {
                while (i < N && collection[startIndex] >= collection[i]) i++;
                while (j > -1 && collection[startIndex] < collection[j]) j--;
                if (i <= j)
                {
                    Swap(i, j, collection);
                }
            }
            Swap(startIndex, j, collection);
            QSort(startIndex, j - 1, collection, N);
            QSort(i, finalIndex, collection, N);
        }
        #endregion
    }
}