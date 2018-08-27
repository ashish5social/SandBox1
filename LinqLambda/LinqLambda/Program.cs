using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLambda
{
    class Program
    {
        delegate int del(int Value);
        static void Main(string[] args)
        {
            //Use to search a list/collection
            List<int> Lst = new List<int>();
            Lst.Add(100);
            Lst.Add(200);
            Lst.Add(300);

            int Value = Lst.Find(m => m.Equals(100));
            //int value = Lst.Find() 

            Console.WriteLine(Value);
            Console.ReadLine();

            //Find series of number 
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var evens = numbers.FindAll(n => n % 2 == 0);
            foreach (int a in evens)
            {
                Console.WriteLine(a);
            }
            Console.ReadLine();

            del MyDelegate = X => X * X;
            Console.WriteLine("Result is := " + MyDelegate(5));
            Console.ReadLine();
        }
    }
}
