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

	// Complete the whatFlavors function below.
	static void whatFlavors(int[] cost, int money)
	{
		//List<string> data = new List<string>(); 
		//for (int i = 0; i < cost.Length; i++)
		//{
		//	data.Add
		//}
		

		//Array.Sort(cost); 
		//HashSet<int> set = new HashSet<int>(); 
		//for(int i =0; i<cost.Length; i++) {
		//  set.Add(cost[i]; 
		//}
		//Now set will have all unique costs in ascending order. 
		//If there are duplicates, then it does not matter whether it exists or no, so we can delete them. 

		//        int moneyAvailable = money; 
		Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
		for (int i = 0; i < cost.Length; i++)
		{
			if (dict.ContainsKey(cost[i]))
			{
				dict[cost[i]].Add(i + 1);
			}
			else
			{
				List<int> l = new List<int>();
				l.Add(i + 1);
				dict[cost[i]] = l; 
			}
		}
		foreach (int key in dict.Keys)
		{
			if (dict.ContainsKey(money - key))
			{
				if (key == money - key)
				{
					//This will be acceptable only if there are more than 1 values in the corresponding list. in that case print 1st and 2nd index
					if (dict[key].Count > 1)
					{
						Console.WriteLine("{0} {1}", dict[key][0], dict[money - key][1]);
						break; 
					}
					else
					{
						continue; 
					}
				}
				Console.WriteLine("{0} {1}", dict[key][0], dict[money - key][0]);
				break;
			}
		}

		
	}

	static void Main(string[] args)
	{
		int t = Convert.ToInt32(Console.ReadLine());
		
		for (int tItr = 0; tItr < t; tItr++)
		{
			int money = Convert.ToInt32(Console.ReadLine());

			int n = Convert.ToInt32(Console.ReadLine());
			int[] cost = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), costTemp => Convert.ToInt32(costTemp))
			;
			whatFlavors(cost, money);
		}
	}
}
