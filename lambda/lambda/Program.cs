using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambda
{
    class Program
    {
        //del is a Type like int, string or Customer i.e we can write int iInt = 5 ; same way we can write del subDelegate = Subtract; (Provided we have a method
        // like int Subtract(int l) // Subtract can be anyname, but Input argument must be One int and Return must be Int.  
        delegate int del(int i);
        static void Main(string[] args)
        {
            // The Three Parts of a LINQ Query:
            //  1. Data source.
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;
            // num is temporary int variable as numbers is a collection/array of type int. So numQuuery when executed, will get one row from numbers datatable, 
            // and then select that num if num%2 is 0  

            // 3. Query execution.
            foreach (int num in numQuery)
            {
                //Console.Write("{0} ", num);
                Console.Write("{0,1} ", num);
            }

            del myDelegate = x => x * x;
            int j = myDelegate(5); //j = 25  
            Console.WriteLine("j is {0}", j);
            del addDelegate = y => y + 10;
            j = addDelegate(25);
            Console.WriteLine("j is {0}", j);
            //del subDelegate = Subtract;
            //Instead of creating a separate method named Subtract, we can use inline method definition. z before => is the input to a method - and this z is of type int as we are assigning this anon method to a delegate, which can take int as input.. right?, and even if we do not give return statement,  
            // del subDelegate = z => z - 5;  In this case only statement is z-5; and that itself is considered as return z-5
            // If there are multi line u need to use { and then u must specifically return int type. 
            //del subDelegate = z =>
            //{
            //    return z - 5;
            //}; 
            del subDelegate = z =>
            {
                z = z - 5;
                return z;
            };
            j = subDelegate(30);
            Console.WriteLine("j is {0}", j);
        }

        public static int Subtract(int l)
        {
            return l - 5;
        }
    }
}
