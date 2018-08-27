using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gfg
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the test input : \nNumber of tests \nNumber of elements \nElements seperated by space; \nwhen done press one more enter");
			string currentLine = "";
			string input = ""; 
			do
			{
				currentLine = Console.ReadLine();
				input = input + "\n" + currentLine; 
			} while (!String.IsNullOrWhiteSpace(currentLine));
			Console.WriteLine("input is :\n" + input);
			string[] inputArray = input.Split('\n');
			string discard = inputArray[0];
			int totalTestData; 
			if (!Int32.TryParse(inputArray[1], out totalTestData))
			{
				Console.WriteLine("Exception thrown"); 
			}
			InputData[] inputData = new InputData[totalTestData]; 
			//If there are 2 totalTestData, that means there will emptyLine, 2, CountOfTestInput1, TestInput1, CountOfTestInput2, Testinput2, emptyLine
			for (int i = 0; i < totalTestData; i++)
			{
				inputData[i] = new InputData(); 
				inputData[i].CountOfData= Convert.ToInt32(inputArray[2 * i + 2]);
				string input1 = inputArray[2 * i + 3];
				//int[] InputData1 = new int[inputData[i].CountOfData];
				int j = 0;
				string[] input1Splitted = input1.Split(' ');
				int lenghtOfTestData = input1Splitted.Length;
				inputData[i].TestData = new int[lenghtOfTestData]; 
				foreach (string input11 in input1.Split(' ')) {
					inputData[i].TestData[j++] = Convert.ToInt32(input11); 
				}
			}

			Console.WriteLine("Totaltest data is " + totalTestData);
			for (int k = 0; k < totalTestData; k++)
			{
				Console.WriteLine("\n"+ (k + 1) + ": Test data :");
				Console.WriteLine("Total input numbers : " + inputData[k].CountOfData);
				Console.Write("Input numbers : "); 
				for (int l = 0; l < inputData[k].TestData.Length; l++)
				{
					Console.Write(inputData[k].TestData[l] + " ");
				}
				Console.WriteLine();
			}

			// So till here I have Array of inputData. 
			for (int m = 0; m < totalTestData; m++)
			{
				//We need to return the output by finding maximum sum of contiguos subarray 
				//take two pointers ptr1, ptr2.. start ptr1 from 0 .. consider that its highest. Then increase ptr2 until, 
				Console.WriteLine (inputData[m].maxSubArraySum()); 
			}


			Console.WriteLine("\nEnter any key to exit"); 
			Console.ReadKey();  
		}
	}

	class InputData
	{
		public int CountOfData;
		public int[] TestData;
		public int maxSubArraySum()
		{
			int size = CountOfData;
			int max_so_far = int.MinValue,
				max_ending_here = 0;

			for (int i = 0; i < size; i++)
			{
				max_ending_here = max_ending_here + TestData[i];

				if (max_so_far < max_ending_here)
					max_so_far = max_ending_here;

				if (max_ending_here < 0)
					max_ending_here = 0;
			}

			return max_so_far;
		}
	}
}
