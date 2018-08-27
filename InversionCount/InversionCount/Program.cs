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

	// Complete the countInversions function below.
	static long countInversions(int[] arr)
	{
		return CountOfInversionInMergeSort(arr, 0, arr.Length - 1);
	}

	static long CountOfInversionInMergeSort(int[] arr, int low, int high)
	{
		long count = 0;
		if (low < high)
		{
			int mid = (high + low) / 2;
			count = CountOfInversionInMergeSort(arr, low, mid);
			count += CountOfInversionInMergeSort(arr, mid + 1, high);
			count += CountOfInversionInMerge(arr, low, mid+1, high);
		}
		return count;
	}

	static long CountOfInversionInMerge(int[] arr, int low, int mid, int high)
	{
		int count = 0;
		int i = low; int j = mid; int k = low;
		int[] temp = new int[arr.Length];
		while (i <= mid - 1 && j <= high)
		{
			if (arr[i] <= arr[j])
			{
				temp[k++] = arr[i];
				i++; 
			}
			else
			{
				temp[k++] = arr[j];
				j++; 
				count += count + (mid - i);
			}
		}
		while (i <= mid - 1)
		{
			temp[k++] = arr[i++];
		}
		while (j <= high)
		{
			temp[k++] = arr[j++];
		}
		for (int l = low; i <= high; i++)
		{
			arr[l] = temp[l];
		}

		return count;
	}

	static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int t = Convert.ToInt32(Console.ReadLine());

		for (int tItr = 0; tItr < t; tItr++)
		{
			int n = Convert.ToInt32(Console.ReadLine());

			int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
			;
			long result = countInversions(arr);

			Console.WriteLine(result);
		}

		//textWriter.Flush();
	//	textWriter.Close();
	}
}
