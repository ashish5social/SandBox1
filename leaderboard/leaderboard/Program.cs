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

	// Complete the climbingLeaderboard function below.
	static int[] climbingLeaderboard(int[] scores, int[] alice)
	{
		//int[] distinctScores = scores.Distinct().ToArray();
		int[] result = new int[alice.Length];
		for (int i = 0; i < alice.Length; i++)
		{
			//Foreach Alice's result, get the rank
			result[i] = GetRank(scores, alice[i]);
		}
		//Make array distinct; 
		return result;
	}

	public static int GetRank(int[] arr, int pivot)
	{
		if (arr[0] <= pivot)
		{
			return 1;
		}
		//else if (arr[arr.Length - 1] > pivot)
		//{
		//	return arr.Length + 1;
		//}
		//else if (arr[arr.Length - 1] == pivot)
		//{
		//	return arr.Length;
		//}
		int rank = 1;
		int i; 
		for (i = 0; i < arr.Length-1; i++)
		{
			if (pivot < arr[i] && pivot > arr[i + 1])
				return rank + 1;
			else if (pivot == arr[i])
				return rank; 
			if (arr[i] != arr[i + 1])
				rank++;
		}
		if (pivot == arr[arr.Length - 1])
		{
			return rank;
		}
		else
		{
			return rank+1;
		}
	}

	static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int scoresCount = Convert.ToInt32(Console.ReadLine());

		int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp))
		;
		int aliceCount = Convert.ToInt32(Console.ReadLine());

		int[] alice = Array.ConvertAll(Console.ReadLine().Split(' '), aliceTemp => Convert.ToInt32(aliceTemp))
		;
		int[] result = climbingLeaderboard(scores, alice);

		Console.WriteLine(string.Join("\n", result));

		//textWriter.Flush();
		//textWriter.Close();
	}
}
