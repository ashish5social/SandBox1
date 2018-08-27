using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace regex1
{
	class Program
	{
		static void Main(string[] args)
		{
			string pattern = @"(\ba\d+z\b)"; 
			string[] words = { "asdsdz", "a11212z12", "12a2323z", "a2333z", "az" };
			foreach (string word in words)
			{
				MatchCollection matchCollection = Regex.Matches(word, pattern);
				foreach (Match match in matchCollection)
				{
					Console.WriteLine(""); 
				}
			}
		}
	}
}
