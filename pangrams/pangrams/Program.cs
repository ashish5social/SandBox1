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

	// Complete the pangrams function below.
	static string pangrams(string s)
	{
		Dictionary<char, int> alpha = new Dictionary<char, int>();
		// 97 = a; 
		//for (int i = 0;  i<26; i++) {
		//  Console.WriteLine(int(c))
		//}
		for (char c = 'a'; c <= 'z'; c++)
		{
			alpha[c] = 0;
			//do something with letter 
		}

		for (int i = 0; i < s.Length; i++)
		{
			if (alpha.ContainsKey(s[i] )) {
				alpha[s[i]] = alpha[s[i]] + 1;
			}


		}
		//Now check that none of the key has value = 0; 
		foreach (char c in alpha.Keys)
		{
			if (alpha[c] == 0)
			{
				return "not pangram";
			}
		}
		return "pangram";
	}

static void Main(string[] args)
{
	TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

	string s = Console.ReadLine();

	string result = pangrams(s);

	textWriter.WriteLine(result);

	textWriter.Flush();
	textWriter.Close();
}
}
