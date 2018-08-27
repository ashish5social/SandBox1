using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoConsole1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("How many players? chose the number from below: ");
			Console.WriteLine("1 : One player playing against computer");
			Console.WriteLine("2 : Two player playing against each other");
			Game game = new Game(2);
			game.Start(); 

		}
	}
}
