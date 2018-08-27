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

	// Complete the sherlockAndAnagrams function below.
	static int sherlockAndAnagrams(string s)
	{
		List<string> l = new List<string>();
		string m = "";
		//Get all possible substring of s. 
		for (int i = 0; i < s.Length; i++)
		{
			for (int j = 1; j <= s.Length - i; j++)
			{
				m = s.Substring(i, j);
				char[] carray = m.ToCharArray(); 
				Array.Sort(carray);
				l.Add(new string(carray));
			}
		}
		int count = 0;
		//Dictionary<string, 
		for(int i = 0; i< l.Count; i++)
		{
			string a = l[i]; 
			for(int j = i+1; j< l.Count; j++) 
			{
				string b = l[j]; 
				Console.WriteLine("Comparing " + a + " and " + b);
				if (a == b)
					count++; 
			}
			
		}
		return count; 
	}

	static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int q = Convert.ToInt32(Console.ReadLine());

		for (int qItr = 0; qItr < q; qItr++)
		{
			string s = Console.ReadLine();

			int result = sherlockAndAnagrams(s);

			Console.WriteLine(result);
		}

		Console.ReadLine(); 
		//textWriter.Flush();
		//textWriter.Close();
	}
}
