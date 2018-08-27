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

	// Complete the cavityMap function below.
	static string[] cavityMap(string[] grid)
	{
		string[] result = new string[grid.Length];
		for (int i = 0; i < grid.Length; i++)
		{
			for (int j = 0; j < grid.Length; j++)
			{
				if (i == 0 || i == grid.Length - 1 || j == 0 || j == grid.Length - 1)
				{
					result[i] = result[i] + grid[i][j];
				}
				else
				{
					//Check if its cavity. 
					
					int c = Int32.Parse(grid[i][j].ToString());
					int right = Int32.Parse(grid[i][j + 1].ToString());
					int bottom = Int32.Parse(grid[i + 1][j].ToString());
					int left = Int32.Parse(grid[i][j - 1].ToString());
					int up = Int32.Parse(grid[i - 1][j].ToString());
					if (c > right && c > bottom && c > left && c > up)
					{
						result[i] = result[i] + "X";
					}
					else
					{
						result[i] = result[i] + grid[i][j];
					}
				}
			}

		}
		return result; 
	}
		static void Main(string[] args) {
			//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

			int n = Convert.ToInt32(Console.ReadLine());

			string[] grid = new string[n];

			for (int i = 0; i < n; i++)
			{
				string gridItem = Console.ReadLine();
				grid[i] = gridItem;
			}

			string[] result = cavityMap(grid);

			Console.WriteLine(string.Join("\n", result));

			//textWriter.Flush();
			//textWriter.Close();
		}
	}
