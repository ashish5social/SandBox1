using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "ABCD";

            char[] charArry1 = str1.ToCharArray();

            char c = Convert.ToChar(str1.Substring(0, 1));
            string str = str1.Substring(1);

            char[] charArry = str.ToCharArray();

            permute(charArry, 0, 3);
            Console.ReadKey();
        }

        static void permute(char[] arry, int i, int n)
        {
            int j;
            if (i == n)
                Console.WriteLine(arry);
            else
            {
                for (j = i; j <= n; j++)
                {
                    swap(ref arry[i], ref arry[j]);
                    permute(arry, i + 1, n);
                    swap(ref arry[i], ref arry[j]); //backtrack
                }
            }
        }

        static void swap(ref char a, ref char b)
        {
            char tmp;
            tmp = a;
            a = b;
            b = tmp;
        }
    }
}

