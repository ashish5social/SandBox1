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

	//	short.MaxValue:  32767
	//short.MinValue: -32768
	//ushort.MaxValue: 65535
	//ushort.MinValue: 0
	//long.MaxValue:    2,147,483,647
	//long.MinValue:   -2,147,483,648
	//ulong.MaxValue:   4,294,967,295
	//ulong.MinValue:   0
	//long.MaxValue:   9,223,372,036,854,775,807
	//long.MinValue:  -9,223,372,036,854,775,808
	// Complete the riddle function below.
	//static long[] riddle(long[] arr)
	//{
	//	// complete this function
	//	long[] data = new long[arr.Length]; 
	//	for (long i = 0; i < arr.Length; i++)
	//	{
	//		data[i] = generateMaxOfMinsForGivenWindowSize(i + 1, arr) ;
	//	}
	//	return data; 
	//}

	//static long generateMaxOfMinsForGivenWindowSize(long w, long[] arr)
	//{
	//	long currentMax = long.MinValue;
	//	long data1; 
	//	for (long i = 0; i + w <= arr.Length; i++)
	//	{
	//		data1 = MinForOneSet(arr, i, i + w - 1);
	//		if (data1 > currentMax)
	//		{
	//			currentMax = data1;
	//		}
	//	}
	//	return currentMax;
	//}

	//static long MinForOneSet(long[] arr, long start, long end)
	//{
	//	long currentMin = long.MaxValue;
	//	for (long i = start; i <= end; i++)
	//	{
	//		if (arr[i] < currentMin)
	//		{
	//			currentMin = arr[i];
	//		}
	//	}
	//	return currentMin;
	//}

	static long[] riddle(long[] arr)
	{
		// complete this function
		long[] result = new long[arr.Length];
		long size = arr.Length;
		long[,] Min = new long[size,size];
		long lmax1 = long.MinValue; 
		for (long k = 0; k < size; k++)
		{
			// Min[2][1] means for window of (2+1) 3, starting from 1st index number (j index=1), what is the min?
			Min[0,k] = arr[k];
			if (Min[0,k] > lmax1)
			{
				lmax1 = Min[0,k]; 
			}
		}
		result[0] = lmax1; 
		for (long i = 1; i < size; i++)
		{
			
			long localMax = long.MinValue;
			for (long j = 0; j < size-i; j++)
			{
				// Example Min[1][0] = Minimum of Min[0,0] and arr[1] 
				Min[i,j] = Min[i - 1,j] < arr[j+i] ? Min[i - 1,j] : arr[j+i];
				if (Min[i,j] > localMax)
				{
					localMax = Min[i,j]; 
				}
			}
			result[i] = localMax;
		}
		return result;
	}

	static long[] riddle(long[] arr)
	{
		long[] result = new long[arr.Length];
		int n = arr.Length; 
		// Used to find previous and next smaller
		Stack<long> s = new Stack<long>();

		// Arrays to store previous and next smaller
		long[] left = new long[n + 1];
		long[] right = new long[n + 1];

		// Initialize elements of left[] and right[]
		for (int i = 0; i < n; i++)
		{
			left[i] = -1;
			right[i] = n;
		}

		// Fill elements of left[] using logic discussed on
		// https://www.geeksforgeeks.org/next-greater-element/
		for (int i = 0; i < n; i++)
		{
			while (!(s.Count==0) && arr[s.Peek()] >= arr[i])
				s.Pop();

			if (!(s.Count == 0))
				left[i] = s.Peek();

			s.Push(i);
		}

		// Empty the stack as stack is going to be used for right[]
		while (!(s.Count == 0))
			s.Pop();

		// Fill elements of right[] using same logic
		for (int i = n - 1; i >= 0; i--)
		{
			while (!(s.Count == 0) && arr[s.Peek()] >= arr[i])
				s.Pop();

			if (!(s.Count == 0))
				right[i] = s.Peek();

			s.Push(i);
		}

		// Create and initialize answer array
		long[] ans = new long[n + 1];
		for (int i = 0; i <= n; i++)
			ans[i] = 0;

		// Fill answer array by comparing minimums of all
		// lengths computed using left[] and right[]
		for (int i = 0; i < n; i++)
		{
			// length of the interval
			long len = right[i] - left[i] - 1;

			// arr[i] is a possible answer for this length 
			// 'len' interval, check if arr[i] is more than
			// max for 'len'
			ans[len] = Math.Max(ans[len], arr[i]);
		}

		// Some entries in ans[] may not be filled yet. Fill 
		// them by taking values from right side of ans[]
		for (int i = n - 1; i >= 1; i--)
			ans[i] = Math.Max(ans[i], ans[i + 1]);

		// Print the result
		for (int i = 1; i <= n; i++)
			result[i-1] = ans[i] ;
		return result; 
	}


	static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		Console.WriteLine("Enter numlongegers followed by numbers in next line"); 
		long n = Convert.ToInt64(Console.ReadLine());

		long[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt64(arrTemp));
		long[] res = riddle(arr);

		Console.WriteLine("Answer is :"); 
		Console.WriteLine(string.Join(" ", res));

		Console.ReadKey(); 
	}
}
