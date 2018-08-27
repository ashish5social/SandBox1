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
using System.Threading; 

[Serializable]
public class InvalidNumberException : Exception
{
	public InvalidNumberException() : base(String.Format("string is two"))
	{
		Console.WriteLine("called ce #1"); 
	}

	public InvalidNumberException(string t)
		: base(String.Format("Invalid string : {0}", t))
	{
		Console.WriteLine("called ce #2");
	}
}

class Solution
{

	// Complete the checkMagazine function below.
	static void checkMagazine(string[] magazine, string[] note)
	{

		//Dictionary<string, bool> noteMatching = new Dictionary<string, bool>();
		//Dictionary<string, int> magzineUsedWord = new Dictionary<string, int>();
		Hashtable noteMatching = new Hashtable();
		Hashtable magzineUsedWord = new Hashtable(); 
		foreach (string b in magazine)
		{
			if(b.Equals("two")) {
				throw new InvalidNumberException(b); 
			}
			if (magzineUsedWord.ContainsKey(b))
			{
				magzineUsedWord[b] = (int)magzineUsedWord[b] + 1;
			}
			else
			{
				magzineUsedWord[b] = 1;
			}
		}
		foreach (string a in note)
		{
			if (magzineUsedWord.ContainsKey(a))
			{
				if ((int)magzineUsedWord[a] < 1)
				{
					noteMatching[a] = false;
				}
				else
				{
					noteMatching[a] = true;
					magzineUsedWord[a] = (int)magzineUsedWord[a] - 1;
				}
			}
		}
		// Can not reuse a string from magzine.
		bool matching = true;
		foreach (string a in note)
		{
			if (!noteMatching.ContainsKey(a) || (bool)noteMatching[a] != true)
			{
				matching = false;
			}
		}
		if (matching == true)
		{
			Console.WriteLine("Yes");
			
		}
		else
		{
			Console.WriteLine("No");
		}

	}

	static void Main(string[] args)
	{
		//string[] mn = Console.ReadLine().Split(' ');

		//int m = Convert.ToInt32(mn[0]);

		//int n = Convert.ToInt32(mn[1]);

		//string[] magazine = Console.ReadLine().Split(' ');

		//string[] note = Console.ReadLine().Split(' ');



		//try
		//{
		//	checkMagazine(magazine, note);
		//}
		//catch (InvalidNumberException e)
		//{
		//	Console.WriteLine("stack is" +e.Message);
		//	Console.WriteLine("in main exception");
		//}

	//public void myMethod(UltraGrid myGrid, string s)
	//{
	//}

	//Thread t = new Thread(() => myMethod(myGrid, "abc"));
	//t.Start();
			for (int i = 1; i < 3; i++)
			{
				Thread t = new Thread( () => printTable(i) );
				t.Name = "AkThread" + i;
				Console.WriteLine("Starting thread : {0}", t.Name); 
				t.Start(); 
			} 
			Console.ReadKey(); 
		}

		static void printTable(int num)
		{
			Console.WriteLine("Print table for "+num+" one value evey 1 seconds");

		lock(new object())
		{
			for (int i = 1; i <= 10; i++)
			{
				Console.WriteLine(num * i + " ");
				System.Threading.Thread.Sleep(1000);
			}
		}
			Console.WriteLine("This is outside lock and for loop called with num = "+num );
		}
}
