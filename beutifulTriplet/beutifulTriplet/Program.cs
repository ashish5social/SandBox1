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

	// Complete the beautifulTriplets function below.
	static int beautifulTriplets(int d, int[] arr)
	{
		int count = 0;
		for (int i = 0; i < arr.Length - 2; i++)
		{
			//For i=0, is there any element with value arr[0] + d? if yes then 
			int index1 = Array.BinarySearch(arr, arr[i] + d);
			int index2 = Array.BinarySearch(arr, arr[i] + 2 * d);
			Console.WriteLine("i is {0} and index1 is {1} index2 is {2}", i, index1, index2);
			if (index1 > i && index2 > i)
			{
				count++;
				Console.WriteLine("Count is {0}", count);
			}

		}
		return count;
	}

	static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		string[] nd = Console.ReadLine().Split(' ');

		int n = Convert.ToInt32(nd[0]);

		int d = Convert.ToInt32(nd[1]);

		int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
		;
		int result = beautifulTriplets(d, arr);

		Console.WriteLine(result);

		//textWriter.Flush();
		//textWriter.Close();
	}
}
