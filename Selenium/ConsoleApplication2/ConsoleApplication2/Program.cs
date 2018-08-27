using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayNumberAddGame(); 

        }
        public static void PlayNumberAddGame() {
           for (int i = 1; i<=10; i++)
            {
                for (int j = 1; j<=10; j++)
                {
                    Console.Write("How much is " + i + " + " + j + " = ");
                    int result = Convert.ToInt32(Console.ReadLine()); 
                    
                    while (result != (i+j))
                    {
                        Console.WriteLine("You are Wrong ..");
                        Console.WriteLine("Try again ..");
                        Console.Write("How much is " + i + " + " + j + " = ");
                        result = Convert.ToInt32(Console.ReadLine());
                    }
                    if (result == (i + j))
                        Console.WriteLine("You are Correct ..");
                   // System.Threading.Thread.Sleep(5000); 
                   // Console.Clear();
                }
            }
        }
    }
}
