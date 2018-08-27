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

	static void Main(string[] args)
	{
		int N = Convert.ToInt32(Console.ReadLine());

		//Dictionary<string, string> inputData = new Dictionary<string, string>(); 

		string[] firstNames = new string[N];
		string[] emails = new string[N];

		for (int NItr = 0; NItr < N; NItr++)
		{
			string[] firstNameEmailID = Console.ReadLine().Split(' ');

			//inputData[firstNameEmailID[0]] = firstNameEmailID[1]; 
			firstNames[NItr] = firstNameEmailID[0];
			emails[NItr] = firstNameEmailID[1];

		}

		string expr = @"([a-z]+@gmail.com)";
		//		string expr = "\b[a-z]*@gmail.com\b";

		List<string> l = new List<string>(); 
				 
		//Array.Sort(firstNames); 
		for(int i = 0; i<N; i++) 
		{		
			MatchCollection mc = Regex.Matches(emails[i], expr);
			if (mc.Count > 0)
			{
				l.Add(firstNames[i]); 
			}
		}

		l.Sort();
		foreach (string fName in l)
		{
			Console.WriteLine(fName); 
		}

		Console.ReadLine();

	}
}
