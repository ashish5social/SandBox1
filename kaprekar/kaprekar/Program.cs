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

	// Complete the kaprekarNumbers function below.
	static void kaprekarNumbers(int p, int q)
	{
		int count = 0; 
		for (int i = p; i <= q; i++)
		{
			int iLen = i.ToString().Length;
			long square = (long)i * (long)i;
			string s = square.ToString();
			string r = s.Substring(s.Length - iLen, iLen);
			string l = s.Substring(0, s.Length - iLen);
			int ri = 0; 
			if (r.Length!=0)
				ri= int.Parse(r);
			int li = 0; 
			if (l.Length != 0)
				 li = int.Parse(l);
			if (ri + li == i)
			{
				count++;
				Console.Write(i + " ");
			}
		}
		if (count == 0)
			Console.WriteLine("INVALID RANGE"); 

		
	}

	static void Main(string[] args)
	{
		int p = Convert.ToInt32(Console.ReadLine());

		int q = Convert.ToInt32(Console.ReadLine());

		kaprekarNumbers(p, q);
	}
}
