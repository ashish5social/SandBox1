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

	// Complete the morganAndString function below.
	static string morganAndString(string a, string b)
	{
		int m = a.Length;
		int n = b.Length;
		int i = 0;
		int j = 0;
		string result = "";
		if (m == 0 && n == 0)
			return result;
		if (m == 0)
			return b;
		if (n == 0)
			return a;

		while (i < m && j < n)
		{
			int a1 = (int)a[i];
			int b1 = (int)b[j];
			if (a1 < b1)
			{
				result = result + a[i++];
			}
			else if (a1 > b1)
			{
				result = result + b[j++];
			}
			else
			{
				//this means a1==b1. So now compare next ones 
				int k = i + 1;
				int l = j + 1;
				while (k < m && l < n)
				{
					if ((int)(a[k]) == (int)(a[l]))
					{
						k++; l++;
					}
					else
					{
						if ((int)(a[k]) < (int)(a[l]))
						{
							result = result + a[i++];
							break;
						}
						else
						{
							result = result + b[j++];
							break;
						}
					}
				}
				if (k == m)
				{
					result = result + a[i++];
				}
				else
				{
					result = result + b[j++];
				}
			}
		}

		if (i == m)
		{
			result = result + b.Substring(j, n - j);
		}
		else
		{
			result = result + a.Substring(i, m - i);
		}
		return result;
	}
	static void Main(string[] args)
{
	//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

	int t = Convert.ToInt32(Console.ReadLine());

	for (int tItr = 0; tItr < t; tItr++)
	{
		string a = Console.ReadLine();

		string b = Console.ReadLine();

		string result = morganAndString(a, b);

		Console.WriteLine(result);
	}

	//textWriter.Flush();
	//textWriter.Close();
}
}
