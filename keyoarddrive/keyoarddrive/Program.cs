using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{

	/*
     * Complete the getMoneySpent function below.
     */
	static int getMoneySpent(int[] keyboards, int[] drives, int b)
	{
		/*
         * Write your code here.
         */
		Array.Sort(keyboards);
		Array.Sort(drives);
		int m = keyboards.Length;
		int n = drives.Length;
		int price = 0;
		int i = m - 1;
		int j = n - 1;
		//I need to minimize b-keyboards[i]-drives[j] but it should be positive or 0
		if (keyboards[0] + drives[0] > b)
			return -1;
		while (i >= 0 || j >= 0)
		{
			price = keyboards[i] + drives[j];
			if (price > b)
			{
				//i.e we need to decrease any one 
				if (keyboards[i] > drives[j])
				{
					j--;
				}
				else
				{
					i--;
				}
			}
			else
			{
				//Here price is less than b. That means this ith and jth data is making it best pair closest to b.
				return price;
			}
		}

		if (j < 0 && i < 0)
		{
			return keyboards[i + 1] + drives[j + 1];
		}
		else if (j < 0)
		{
			return keyboards[i] + drives[j + 1];
		}
		else
		{
			return keyboards[i + 1] + drives[j];
		}
	}

	static void Main(string[] args)
	{
		//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		string[] bnm = Console.ReadLine().Split(' ');

		int b = Convert.ToInt32(bnm[0]);

		int n = Convert.ToInt32(bnm[1]);

		int m = Convert.ToInt32(bnm[2]);

		int[] keyboards = Array.ConvertAll(Console.ReadLine().Split(' '), keyboardsTemp => Convert.ToInt32(keyboardsTemp))
		;

		int[] drives = Array.ConvertAll(Console.ReadLine().Split(' '), drivesTemp => Convert.ToInt32(drivesTemp))
		;
		/*
         * The maximum amount of money she can spend on a keyboard and USB drive, or -1 if she can't purchase both items
         */

		int moneySpent = getMoneySpent(keyboards, drives, b);

		Console.WriteLine(moneySpent);

		//textWriter.Flush();
		//textWriter.Close();
	}
}
