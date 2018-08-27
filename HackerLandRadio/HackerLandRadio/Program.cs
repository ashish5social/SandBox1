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

	// Complete the hackerlandRadioTransmitters function below.
	static int hackerlandRadioTransmitters(int[] x, int k)
	{
		int size = x.Length;
		int i = 0;
		int j = 0;
		int l = 0;
		List<int> antenaList = new List<int>();
		while (i < size)
		{
			for (j = i + 1; j < size; j++)
			{
				if (x[j] - x[i] > k)
				{
					antenaList.Add(x[j - 1]);
					for (l = j; l < size; l++)
					{
						if (x[l] - x[j - 1] > k)
						{
							i = l;
							break;
						}
					}
					break;
				}
			}
			if (j >= size && i < size)
			{
				antenaList.Add(x[i]);
				break; 
			}
		}
		return antenaList.Count;
	}

	static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		string[] nk = Console.ReadLine().Split(' ');

		int n = Convert.ToInt32(nk[0]);

		int k = Convert.ToInt32(nk[1]);

		int[] x = Array.ConvertAll(Console.ReadLine().Split(' '), xTemp => Convert.ToInt32(xTemp))
		;
		int result = hackerlandRadioTransmitters(x, k);

		Console.WriteLine(result);

		//textWriter.Flush();
		//textWriter.Close();
	}
}
