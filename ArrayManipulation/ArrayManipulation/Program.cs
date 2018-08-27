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
		int[] res = new int[n];
		for (int i = 0; i < size; i++)
		{
			for (int j = queries[i][0]; j <= queries[i][1]; j++)
			{
				res[j-1] = res[j-1] + queries[i][2];
			}
		}
		long localMax = long.MinValue;
		for (int i = 0; i < n; i++)
		{
			if (res[i] > localMax)
			{
				localMax = res[i];
			}
		}
		return localMax;
	}

	static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
		TextWriter textWriter = new StreamWriter("C:\\Users\\askumar\\Documents\\output.txt", true);

		string[] nm = Console.ReadLine().Split(' ');


		int n = Convert.ToInt32(nm[0]);

		int m = Convert.ToInt32(nm[1]);

		int[][] queries = new int[m][];

		for (int i = 0; i < m; i++)
		{
			queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
		}

		long result = arrayManipulation(n, queries);

		textWriter.WriteLine(result);

		textWriter.Flush();
		textWriter.Close();
	}
}
