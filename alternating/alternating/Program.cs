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

	// Complete the alternatingCharacters function below.
	static int alternatingCharacters(string s)
	{
		if (s.Length == 0)
			return 0;
		bool isA = (s[0] == 'A');
		if (s.Length == 1)
		{
			return 0;
		}
		int wrong = 0;
		for (int i = 1; i < s.Length; i++)
		{
			if (isA)
			{
				if (s[i] != 'B')
				{
					wrong++;
				}
				else
				{
					isA = false;
				}
			}
			else
			{
				if (s[i] != 'A')
				{
					wrong++;
				}
				else
				{
					isA = true;
				}
			}
		}
		return wrong;
	}

	static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int q = Convert.ToInt32(Console.ReadLine());

		for (int qItr = 0; qItr < q; qItr++)
		{
			string s = Console.ReadLine();

			int result = alternatingCharacters(s);

			Console.WriteLine(result);
		}

		//textWriter.Flush();
		//textWriter.Close();
	}
}
