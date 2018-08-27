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

	// Complete the minimumDistances function below.
	static int minimumDistances(int[] a)
	{
		//Array.Sort(a);
		int min = int.MaxValue;
		int currentMin = 0;
		int indexPair = 0;
		for (int i = 0; i < a.Length; i++)
		{
			indexPair = Array.IndexOf(a, a[i], i+1, a.Length - i - 1);
			//indexPair = Array.BinarySearch(a, i + 1, a.Length - i-1,  a[i]);
			if (indexPair > 0)
			{
				currentMin = Math.Abs(indexPair - i);
				if (currentMin < min)
					min = currentMin;
			}

		}
		if (min == int.MaxValue)
			return -1;
		else
			return min;

	}

	static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int n = Convert.ToInt32(Console.ReadLine());

		int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
		;
		int result = minimumDistances(a);

		Console.WriteLine(result);

		//textWriter.Flush();
		//textWriter.Close();
	}
}
