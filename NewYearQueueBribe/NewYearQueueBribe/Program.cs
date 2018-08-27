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
	// Complete the minimumBribes function below.
	static void minimumBribes(int[] q)
	{
		int size = q.Length;
		int[] expected = new int[size];
		for (int i = 0; i < size; i++)
		{
			expected[i] = i + 1; 
		}
		int count = 0;
		for (int i = 0; i < size; i++)
		{
			if ((q[i] - (i+1)) > 2)
			{
				Console.WriteLine("Too chaotic");
				return;  
			}
			if ((q[i] - (i+1)) == 2)
			{
				//Exchange ith by ith+1 in expected. 
				int temp = expected[i+1];
				expected[i + 1] = expected[i];
				expected[i] = q[i]; 
				expected[i + 2] = temp;
				count = count + 2;  ;
			} else if (((q[i] - (i+1)) == 1) && q[i] != expected[i])
			{
				// Exchange i+1 th to i+2th and ith to i+1 
				expected[i + 1] = expected[i];
				expected[i] = q[i]; 
				count++; 
			}
		}
		Console.WriteLine(count);
	}

	static void Main(string[] args)
	{
		int t = Convert.ToInt32(Console.ReadLine());

		for (int tItr = 0; tItr < t; tItr++)
		{
			int n = Convert.ToInt32(Console.ReadLine());

			int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp));

			minimumBribes(q);
			Console.ReadLine(); 
		}
	}
}
