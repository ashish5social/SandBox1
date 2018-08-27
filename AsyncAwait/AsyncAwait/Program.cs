using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Start : --------------------");
        Method1();
        Method2();
        Console.WriteLine("End : --------------------");
        Console.ReadKey();
    }

    public static async Task Method1()
    {
        await Task.Run(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(" Method 1 : "+i);
            }
        });
    }

    public static void Method13()
    {
         for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(" Method 13 : "+i );
            }
    }



    public static void Method2()
    {
        for (int i = 0; i < 25; i++)
        {
            Console.WriteLine(" Method 2 : "+i);
        }
    }
}