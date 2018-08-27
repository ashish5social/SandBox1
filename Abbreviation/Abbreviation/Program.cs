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

	static string abbreviation(string a, string b)
	{
		List<char> LeftInA = new List<char>(); 
		bool result = getAbbreviation(a, b, a.Length-1, b.Length-1, LeftInA);
		if (result)
			return "YES";
		return "NO"; 
	}

	private static bool getAbbreviation(string A, string B, int m, int n, List<char> LeftInA)
	{
		//base case. Consider
		if (m == -1 && n != -1) {
			return false;
		}
		if (m == -1 && n == -1)
		{
			return true; 
		}
		if (m != -1 && n == -1) {
			if (isAllCharsInStringLowerCase(LeftInA))
				return true;
			else
				return false; 
		}
		if (m == 0 && n == 0) {
			if ((A[0] == B[0] || char.ToUpper(A[0]) == B[0]) && isAllCharsInStringLowerCase(LeftInA))
				return true;
			else
				return false; 
		}

		if (A[m] == B[n])
		{
			return getAbbreviation(A, B, m - 1, n - 1, LeftInA);
		}
		else if (char.ToUpper(A[m]) == B[n])
		{
			return getAbbreviation(A, B, m - 1, n - 1, LeftInA) || getAbbreviation(A, B, m - 1, n, LeftInA);
		}
		else 
		{
			LeftInA.Add(A[m]); 
			return getAbbreviation(A, B, m - 1, n, LeftInA); 
		}

	}

	static string abbreviationOld(string a, string b)
	{
		int i = 0;
		int j = 0;
		List<char> LeftInA = new List<char>();
		while (i < a.Length && j < b.Length)
		{
			//Compare 1st letter of A and B. are same (here same means, A can be capitalized i.e either A[i] = B[j] or CapsOfA[i]=B[j]). Good, then no point keeping this i and j hence i++ and j++. If if its not same - As A can be discared, lets move A's index. 
			//Now compare if 2nd letter of A is matching with B's 1st letter If matching fine i++ and j++; if not matching can move i. Keep on doing till i reaches end of A. if its matches, then increase both i and j? but i can't be increased further. So essentially, none of letter in A matched to 1st letter in B. Now B's letter cant be removed. SO its NO. 
			//If A's 2nd letter matched 
			if (a[i] == b[j] || Char.ToUpper(a[i]) == b[j])
			{
				i++;
				j++;
			}
			else
			{
				LeftInA.Add(a[i]);
				i++;
			}
		}

		if (i != a.Length)
		{
			LeftInA.AddRange(a.Substring(i, a.Length - i).ToCharArray());
		}
		//This means j could not complete its course. 
		if (j != b.Length)
		{
			return "NO";
		}
		else if (isAllCharsInStringLowerCase(LeftInA))
		{
			return "YES";
		}
		else
		{
			return "NO";
		}
	}

	static bool isAllCharsInStringLowerCase(List<char> LeftInA)
	{
		bool result = true;
		foreach (char c in LeftInA)
		{
			if (char.IsUpper(c))
				return false;
		}
		return result;
	}

	static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int q = Convert.ToInt32(Console.ReadLine());

		for (int qItr = 0; qItr < q; qItr++)
		{
			string a = Console.ReadLine();

			string b = Console.ReadLine();

			string result = abbreviation(a, b);

			Console.WriteLine(result);
		}

		//textWriter.Flush();
		//textWriter.Close();
	}
}
