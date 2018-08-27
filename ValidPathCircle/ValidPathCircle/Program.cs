using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidPathCircle
{
	class Program
	{
		static void Main(string[] args)
		{
			//		Input:
			//		x = 2

			//y = 3

			//N = 1

			//R = 1

			//A = [2, 4]

			//B = [3, 5]
			Console.WriteLine("Enter X, Y, N, R and A, B");
			int x = Int32.Parse(Console.ReadLine());
			int y = Int32.Parse(Console.ReadLine());
			int n = Int32.Parse(Console.ReadLine());
			int r = Int32.Parse(Console.ReadLine());
			string xCoordinates = Console.ReadLine();
			string yCoordinates = Console.ReadLine();
			
			string[] xArray = xCoordinates.Split(' ');
			string[] yArray = yCoordinates.Split(' ');
			List<int> xList = new List<int>();
			List<int> yList = new List<int>();
			
			for(int i = 0; i<xArray.Length; i++)
			{
				xList.Add(Int32.Parse(xArray[i])); 
			}

			for (int i = 0; i < yArray.Length; i++)
			{
				yList.Add(Int32.Parse(yArray[i]));
			}
			string ans = solve(x, y, n, r, xList, yList);
			Console.WriteLine(ans); 


		}

		public static string solve(int A, int B, int C, int D, List<int> E, List<int> F)
		{
			if (E.Count != F.Count)
			{
				return "NO"; 
			}

			for (int i = 0; i < C; i++)
			{//For each circle find the distance between its center and point x, y
				double x = Math.Pow((E[i] - A), 2);
				double y = Math.Pow((F[i] - B), 2);
				double z = Math.Sqrt(x + y);
				if (D >= z)
				{
					return "NO"; 
				}
			}
			return "YES"; 
		}

	}
}
