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

	// Complete the queensAttack function below.
	static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
	{
		//For each blocker, check if its really going to block the path, if no, continue
		//if yes, find out what is the direction its in w.r.to Queen. and then count in that direction
		int count = 0;
		Dictionary<int, int> origCountValue = new Dictionary<int, int>();
		Dictionary<int, int> blockingCountValue = new Dictionary<int, int>(); // If a blocking point's direction is 2, and there is aleady a value in blockingCountValue[2], then compare, which one would have blocked Maximum, then use that only. 
																			  //countValue[0] means Right side, how many count is there till yet. 
																			  //Initially countValue[0] will be set to Highest possible.. then for each obstacle point, get the direction; direction will be returned 0 to 7.
																			  //If the blocking point does not come in any of the 8 path, then return 0 (0 is 

		for (int i = 0; i < obstacles.GetLength(0); i++)
		{
			int Bx = obstacles[i][0];
			int By = obstacles[i][1];
			int direction = getDirection(Bx, By, r_q, c_q);    // Say we get direction. If its not blocking then return -1; 
			switch (direction) {
				case 0:
					break; 
				case 1:
					break; 

			}



			if (Bx == r_q) //This means blocker is on somewhere parallel to x axis, then seen what the By is if 
			{
				if (By > c_q)
					count = count + (n - 1) - (n - By);       // if there was no blocker, then on line parallel to x axis, we should have got n-1 places.
				if (By < c_q)
					count = count + (n - 1) - By;
			}
			if (By == c_q) //This means blocker is on somewhere parallel to y axis, then seen what the Bx is if 
			{
				if (Bx > c_q)
					count = count + (n - 1) - (n - Bx);       // if there was no blocker, then on line parallel to x axis, we should have got n-1 places.
				if (Bx < c_q)
					count = count + (n - 1) - Bx;
			}
			if ((By - c_q > 0 && Bx - r_q < 0 && Math.Abs(Bx - r_q) == Math.Abs(By - c_q))
			{  // This means rightbottom 
			   //Total count adding will be 
				int countToAdd = Math.Min(Math.Abs(

			}


				|| (By - c_q < 0 && Bx - r_q > 0 && Math.Abs(Bx - r_q) == Math.Abs(By - c_q))) 
			



			if ( Bx == r_q || By == c_q || Math.Abs(Bx-r_q) == Math.Abs(By-c_q)) {
				 
		}

	}

	static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		string[] nk = Console.ReadLine().Split(' ');

		int n = Convert.ToInt32(nk[0]);

		int k = Convert.ToInt32(nk[1]);

		string[] r_qC_q = Console.ReadLine().Split(' ');

		int r_q = Convert.ToInt32(r_qC_q[0]);

		int c_q = Convert.ToInt32(r_qC_q[1]);

		int[][] obstacles = new int[k][];

		for (int i = 0; i < k; i++)
		{
			obstacles[i] = Array.ConvertAll(Console.ReadLine().Split(' '), obstaclesTemp => Convert.ToInt32(obstaclesTemp));
		}

		int result = queensAttack(n, k, r_q, c_q, obstacles);

		Console.WriteLine(result);
		Console.ReadLine(); 
		//textWriter.Flush();
		//textWriter.Close();
	}
}
