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

	// Complete the arrayManipulation function below.
	static long arrayManipulation(int n, int[][] queries)
	{
		int size = queries.GetLength(0);
		long[] res = new long[n];
		for (int i = 0; i < size; i++)
		{
			int j = queries[i][0];
			int k = queries[i][1];
			int sum = queries[i][2];
			res[j - 1] = res[j - 1] + sum;
			if (k < n)
				res[k] = res[k] - sum;
		}
		long localMax = 0;
		long s = 0;
		for (int i = 0; i < n; i++)
		{
			s = s + res[i];
			if (s > localMax)
			{
				localMax = s;
			}
		}
		return localMax;
	}

	static void Main(string[] args)
	{
//		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		string[] nm = Console.ReadLine().Split(' ');

		int n = Convert.ToInt32(nm[0]);

		int m = Convert.ToInt32(nm[1]);

		int[][] queries = new int[m][];

		for (int i = 0; i < m; i++)
		{
			queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
		}

		long result = arrayManipulation(n, queries);

		Console.WriteLine(result);

		//textWriter.Flush();
		//textWriter.Close();
	}
}
