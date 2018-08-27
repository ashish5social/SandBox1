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

	// Complete the isValid function below.
	static string isValid(string s)
	{
		Dictionary<char, int> dict = new Dictionary<char, int>();
		
		foreach (char c in s.ToCharArray())
		{
			if (dict.ContainsKey(c))
				dict[c] = dict[c] + 1;
			else
				dict[c] = 1;
		}

		int l = dict.Keys.Count; 
		int[] counts = new int[l];
		int i = 0; 
		foreach (char c in dict.Keys)
		{
			counts[i++] = dict[c]; 
		}
		Array.Sort(counts);
		int min = counts[0];
		int max = counts[l - 1];
		if (min == max)
			return "YES"; 
		if ((max - min) > 1)
			return "NO";
		int countofMin = 0;
		int countofMax = 0;
		foreach (char c in dict.Keys)
		{
			if (dict[c] == min)
				countofMin++;
			if (dict[c] == max)
				countofMax++;
		}
		if (countofMin == 1 || countofMax == 1)
		{
			return "YES";
		}
		else
		{
			return "NO"; 
		}

		
	}

	
	static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		string s = Console.ReadLine();

		string result = isValid(s);

		Console.WriteLine(result);
		Console.ReadKey(); 
		//textWriter.Flush();
		//textWriter.Close();
	}
}