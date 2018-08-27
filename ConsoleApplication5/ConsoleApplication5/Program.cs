using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            HowToSayHello InAsiaMethod = p.InAsia;
            HowToSayHello InAmericaMethod = p.InAmerica; 
            p.PrintMessage(InAsiaMethod);
            p.PrintMessage(InAmericaMethod);
            Console.ReadLine(); 
        }

        delegate string HowToSayHello(string country);

        void PrintMessage(HowToSayHello how)
        {
            Console.WriteLine(how);
        }
        string InAsia(string state)
        {
            return state + "Hello1"; 
        }

        string InAmerica(string state)
        {
            return state + "Hello2";
        }
    }
}
