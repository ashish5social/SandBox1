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

	// Complete the formingMagicSquare function below.
	static int formingMagicSquare(int[][] s)
	{
		List<int[,]> listOfMatrix = new List<int[,]>();

		int[,] matrix1 = new int[3, 3] { { 8, 1, 6 }, { 3, 5, 7 }, { 4, 9, 2 } };
		listOfMatrix.Add(matrix1);
		int[,] matrix2 = new int[3, 3] { { 8, 3, 4 }, { 1, 5, 9 }, { 6, 7, 2 } };
		listOfMatrix.Add(matrix2);
		int[,] matrix3 = new int[3, 3] { { 4, 3, 8 }, { 9, 5, 1 }, { 2, 7, 6 } };
		listOfMatrix.Add(matrix3);
		int[,] matrix4 = new int[3, 3] { { 4, 9, 2 }, { 3, 5, 7 }, { 8, 1, 6} };
		listOfMatrix.Add(matrix4);
		int[,] matrix5 = new int[3, 3] { { 2, 9, 4 }, { 7, 5, 3 }, { 6, 1, 8 } };
		listOfMatrix.Add(matrix5);
		int[,] matrix6 = new int[3, 3] { { 2, 7, 6 }, { 9, 5, 1 }, { 4, 3, 8 } };
		listOfMatrix.Add(matrix6);
		int[,] matrix7 = new int[3, 3] { { 6, 7, 2 }, { 1, 5, 9 }, { 8, 3, 4 } };
		listOfMatrix.Add(matrix7);
		int[,] matrix8 = new int[3, 3] { { 6, 1, 8 }, { 7, 5, 3 }, { 2, 9, 4 } };
		listOfMatrix.Add(matrix8);

		int currentMin = Int32.MaxValue; 
		foreach (var matrix in listOfMatrix)
		{
			int diff = GetDiffFromGivenMatrix(s, matrix);
			if(diff < currentMin)
				currentMin = diff; 
		}

		return currentMin; 
	}

	private static int GetDiffFromGivenMatrix(int[][] s, int[,] matrix)
	{
		int diff = 0;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				diff += Math.Abs(s[i][j] - matrix[i, j]);  
			}
		}
		return diff; 
	}

	static void generateSquare(int n)
	{
		int[,] magicSquare = new int[n, n];

		// Initialize position for 1
		int i = n / 2;
		int j = n - 1;

		// One by one put all values in magic square
		for (int num = 1; num <= n * n;)
		{
			if (i == -1 && j == n) //3rd condition
			{
				j = n - 2;
				i = 0;
			}
			else
			{
				//1st condition helper if next number 
				// goes to out of square's right side
				if (j == n)
					j = 0;

				//1st condition helper if next number is 
				// goes to out of square's upper side
				if (i < 0)
					i = n - 1;
			}

			//2nd condition
			if (magicSquare[i, j] != 0)
			{
				j -= 2;
				i++;
				continue;
			}
			else
				//set number
				magicSquare[i, j] = num++;

			//1st condition
			j++; i--;
		}

		// print magic square
		Console.WriteLine("The Magic Square for "
										   + n + ":");
		Console.WriteLine("Sum of each row or column "
						 + n * (n * n + 1) / 2 + ":");

		for (i = 0; i < n; i++)
		{
			for (j = 0; j < n; j++)
				Console.Write(magicSquare[i, j] + " ");
			Console.WriteLine();
		}
	}



	static void Main(string[] args)
	{
//		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int[][] s = new int[3][];

		for (int i = 0; i < 3; i++)
		{
			s[i] = Array.ConvertAll(Console.ReadLine().Split(' '), sTemp => Convert.ToInt32(sTemp));
		}

		int result = formingMagicSquare(s);

		Console.WriteLine(result);

		//textWriter.Flush();
		//textWriter.Close();
	}
}

