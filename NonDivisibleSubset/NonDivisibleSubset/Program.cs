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

	// Complete the nonDivisibleSubset function below.
	static int nonDivisibleSubset(int k, int[] S)
	{
		int curentSum = 0; 
		for (int i = S.Length - 1; i > 0; i--)
		{
			//If for ith element
		}


	}

	static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		string[] nk = Console.ReadLine().Split(' ');

		int n = Convert.ToInt32(nk[0]);

		int k = Convert.ToInt32(nk[1]);

		int[] S = Array.ConvertAll(Console.ReadLine().Split(' '), STemp => Convert.ToInt32(STemp))
		;
		int result = nonDivisibleSubset(k, S);

		Console.WriteLine(result);

		//textWriter.Flush();
		//textWriter.Close();
	}
}
