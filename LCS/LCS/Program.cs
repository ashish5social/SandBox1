using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCS
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Enter the strings");
			//string s1 = Console.ReadLine();
			//string s2 = Console.ReadLine();
			string s1 = "AGGTAB";
			string s2 = "GXTXAYB"; 

			int countOfLCS = LCS(s1, s1.Length, s2, s2.Length);
			Console.WriteLine("count of LCS is {0}", countOfLCS);
			Console.ReadLine(); 

		}

		static int LCS(string s1, int m, string s2, int n) {
			//if s1 and s2 both are null, return 0
			int[,] L = new int[m + 1, n + 1];

			for (int i = 0; i <= m; i++)
			{
				for (int j = 0; j <= n; j++)
				{
					//Build L[0,0]
					if (i == 0 || j == 0)
					{
						L[i, j] = 0;
					}
					else if (s1[i-1] == s2[j-1])
					{
						L[i, j] = 1 + L[i - 1, j - 1];
					}
					else
					{
						L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]); 
					}
				}
			}

			int index = L[m, n];
			int temp = index; 
			char[] lcsArray = new char[index + 1];
			lcsArray[index] = '\0';
			int k = m, l = n;
			while (k > 0 && l > 0)
			{
				if (s1[k - 1] == s2[l - 1])
				{
					lcsArray[index - 1] = s1[k - 1];
					k--;
					l--;
					index--;
				}
				else if (L[k - 1, l] > L[k, l - 1])
				{
					k--;
				}
				else
				{
					l--; 
				}
			}

			Console.WriteLine("LCS is :");
			foreach (char c in lcsArray)
			{
				Console.Write(c); 
			}
			
			return temp; 

			
		} 
	}
}
