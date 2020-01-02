using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxContiguous
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 31 , -41 , 59 , 26 , -53 , 58 , 97 , -93 , -23 , 84 };
            var total = a[0];
            var current = a[0];
            var start = 0;
            var end = 0;
            var isStart = true;

            for (var i = 1; i < a.Length; i++)
            {
                current = Math.Max(a[i], current + a[i]);
                if (current == a[i])
                    isStart = true;
                if (total >= current) continue;
                if(isStart)
                    start = i;
                isStart = false;
                end = i;
                total = current;

            }

            Console.WriteLine($"Total : {total}\nStart : {start}\nEnd   : {end}");
        }
    }
}
