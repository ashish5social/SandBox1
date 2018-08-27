using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Solution {
static void Main(string[] args)
{
	//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

	int commandsCount = Convert.ToInt32(Console.ReadLine().Trim());

	List<string> commands = new List<string>();

	for (int i = 0; i < commandsCount; i++)
	{
		string commandsItem = Console.ReadLine();
		commands.Add(commandsItem);
	}

	List<int> res = commandCount(commands);

	Console.WriteLine(String.Join("\n", res));
		Console.ReadLine(); 

	//textWriter.Flush();
	//textWriter.Close();
}

// Complete the commandCount function below.
static List<int> commandCount(List<string> commands)
{
	List<int> res = new List<int>();
	foreach (string command in commands)
	{
			int count = 0; 
		
			HashSet<string> slist = new HashSet<string>();
			for (int i = 0; i < command.Length; i++)
			{
				for (int j = 1; j+i <= command.Length; j++)
				{
					slist.Add(command.Substring(i, j));
					//Console.WriteLine(command.Substring(i, j));
				}
			}
			//Console.WriteLine("Answer"); 
			foreach (string s1 in slist) {
				Regex exp = new Regex(@"(\b[a-z][a-z0-9:]*/[a-z0-9]+\\[a-z]+\b)");
				var results = exp.Matches(s1);
				foreach (Match match in results)
				{
					//Console.WriteLine(match.Value);
					count++;
				}
		}
			res.Add(count); 
	}
	return res;
	}
}