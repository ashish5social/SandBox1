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

	// Complete the freqQuery function below.
	static List<int> freqQuery(List<List<int>> queries)
	{
		int size = queries.Count;
		List<int> arr = new List<int>();
		List<int> res = new List<int>();
		Dictionary<int, int> dict = new Dictionary<int, int>();
		for (int i = 0; i < size; i++)
		{
			List<int> a = queries[i];
			int operation = a[0];
			int item = a[1];
			if (operation == 1)
			{
				if (dict.ContainsKey(item)) {
					dict[item] = dict[item] + 1; ;
				}
				else
				{
					dict[item] = 1;
				}
			}
			else if (operation == 2)
			{
				if (dict.ContainsKey(item)) {
					dict[item] = dict[item] - 1;
				}
			}
			else if (operation == 3)
			{
				if (dict.ContainsValue(item))
				{
					res.Add(1);
					//Console.WriteLine("1"); 
				}
				else
				{
					res.Add(0);
					//Console.WriteLine("0"); 
				}
			}

		}

		return res;
	}

	static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter("C:\\temp\\test.txt", true);

		int q = Convert.ToInt32(Console.ReadLine().Trim());

		List<List<int>> queries = new List<List<int>>();

		for (int i = 0; i < q; i++)
		{
			queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
		}

		List<int> ans = freqQuery(queries);

		textWriter.WriteLine(String.Join("\n", ans));

		textWriter.Flush();
		textWriter.Close();
	}
}
