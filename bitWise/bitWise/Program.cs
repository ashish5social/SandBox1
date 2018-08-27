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
	
	static void Main(string[] args)
	{
		int t = Convert.ToInt32(Console.ReadLine());
		int[] Narray = new int[t];
		int[] Karray = new int[t];
		for (int tItr = 0; tItr < t; tItr++)
		{
			string[] nk = Console.ReadLine().Split(' ');
			int n = Convert.ToInt32(nk[0]);
			Narray[tItr] = n;
			int k = Convert.ToInt32(nk[1]);
			Karray[tItr] = k;
		}

		int localMax = int.MinValue;
		for (int i = 0; i < t; i++)
		{
			for (int j = 1; j <= Narray[i]; j++)
			{
				for (int k = j + 1; k <= Narray[i]; k++)
				{
					int value = j & k;
					if (value < Karray[i])
					{
						//Now check if this is Max
						if (value > localMax)
							localMax = value;
					}
				}
			}
			Console.WriteLine(localMax); 
		}

	}
}
