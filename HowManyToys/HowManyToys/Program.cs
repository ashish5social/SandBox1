using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

	// Complete the howManyGames function below.
	static int howManyGames(int p, int d, int m, int s)
	{
		// Return the number of games you can buy
		int count = 0;
		while (s >= 0)
		{
			int priceForCurrentItem = p - d * count;
			if (priceForCurrentItem > m)
			{
				s -= priceForCurrentItem;
				if (s > 0)
					count++;
				else
					break; 
			}
			else
			{
				priceForCurrentItem = m;
				s -= priceForCurrentItem;
				if (s > 0)
					count++;
				else
					break;
			}
		}
		return count; 

	}

	static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		string[] pdms = Console.ReadLine().Split(' ');

		int p = Convert.ToInt32(pdms[0]);

		int d = Convert.ToInt32(pdms[1]);

		int m = Convert.ToInt32(pdms[2]);

		int s = Convert.ToInt32(pdms[3]);

		int answer = howManyGames(p, d, m, s);

		Console.WriteLine(answer);

		//textWriter.Flush();
		//textWriter.Close();
	}
}
