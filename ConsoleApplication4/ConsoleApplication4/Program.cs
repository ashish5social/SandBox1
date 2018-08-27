using System;
using System.Collections.Generic;
using NetSpell.SpellChecker.Dictionary;
using NetSpell.SpellChecker;
using System.Linq;

//This app takes input as a string and prints all possible combination of possible disctionary word. 
namespace ConsoleApplication4
{
    class Program
    {
        public static List<string> output = new List<string>();
        public static List<string> output1 = new List<string>();
        public static List<string> output2 = new List<string>();
        public static void printCombination(char[] arr, int n, int r)
        {
            // A temporary array to store all combination one by one
            char[] data = new char[r];
            combinationUtil(arr, data, 0, n - 1, 0, r);
        }

        public static void combinationUtil(char[] arr, char[] data, int start, int end, int index, int r)
        {
            if (index == r)
            {
                string s = "";
                for (int j = 0; j < r; j++)
                {
                    Console.Write(data[j]);
                    s = s.Insert(j, data[j].ToString());
                }
                output.Add(s);
                Console.WriteLine();
                // for (int j = r-1; j >= 0; j--)
                //   Console.Write(data[j]);
                //Console.WriteLine();
                return;
            }

            for (int i = start; i <= end && end - i + 1 >= r - index; i++)
            {
                data[index] = arr[i];
                combinationUtil(arr, data, i + 1, end, index + 1, r);
            }
        }

        static void Main(string[] args)
        {
            //char[] arr = { 'A', 'C', 'T', 'P' };
            Console.WriteLine("Enter the word");
            string input = Console.ReadLine();
            char[] arr = input.ToCharArray();

            // int r = 2;
            int n = arr.Length;
            for (int i = 3; i <= n; i++)
            {
                Console.WriteLine("Printing words with {0} characters", i);
                printCombination(arr, n, i);
                // permute(arr, 0, i);
            }

            Console.WriteLine("Printing all strings");
            foreach (var item in output)
            {
                Console.WriteLine("For {0}, possible permutations", item);
                //if (item.Length > 1)
                permute(item.ToCharArray(), 0, item.Length - 1);
            }

            WordDictionary oDict = new WordDictionary();
            oDict.DictionaryFile = "en-US.dic";
            oDict.Initialize();
            // string wordToCheck = "door";
            Spelling oSpell = new Spelling();
            oSpell.Dictionary = oDict;

            foreach (var item in output1)
            {
                // Console.WriteLine(item);
                if (oSpell.TestWord(item))
                {
                    output2.Add(item);
                    Console.WriteLine("Word {0} is a valid english word", item);
                }
            }

            Console.WriteLine("\n\n Final output is ===================== ");
            var distinctList = output2.Distinct().ToList();
            foreach (var item in distinctList)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }



        static void permute(char[] arry, int i, int n)
        {
            int j;
            if (i == n)
            {
                Console.WriteLine(arry);
                string s = new string(arry);
                output1.Add(s);
            }
            else
            {
                for (j = i; j <= n; j++)
                {
                    swap(ref arry[i], ref arry[j]);
                    permute(arry, i + 1, n);
                    swap(ref arry[i], ref arry[j]); //backtrack
                }
            }
        }

        static void swap(ref char a, ref char b)
        {
            char tmp;
            tmp = a;
            a = b;
            b = tmp;
        }

        /*
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the word");
            string input = Console.ReadLine();
            char[] charArry = input.ToCharArray();
            char[] origArray = charArry;
            List<string> output = new List<string>();
            List<string> output1 = new List<string>();
            output = GetPossibleCombination(charArry, output1, origArray); 
            foreach(string item in output)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine(); 
        }

        public static List<string> GetPossibleCombination(char[] charArry, List<string> output1, char[] origArray)
        {
           
           // if (charArry.Length < 2)
           // {
             //   Console.WriteLine("Invalid input");
            //}

            if (charArry.Length == 2)
            {
                //Return list with ab and ba 
                output1.Add((charArry[0]).ToString() + charArry[1].ToString());
                output1.Add((charArry[1]).ToString() + charArry[0].ToString());
                return output1; 
            } else
            {
                for (int i=0; i<charArry.Length; i++)
                {
                    string str = new string(charArry);
                    char c = charArry[i];
                    str = str.Remove(i, 1);
                    charArry = str.ToCharArray();
                    List<string> output2 = GetPossibleCombination(charArry, output1, origArray);
                    List<string> output3 = new List<string>();
                  //  output3.Add("bc");
                   // output3.Add("cb");
                    for (int j= output2.Count-1; j >=0; j--)
                    {
                        output1.Add(c.ToString() + output2.ElementAt(j));
                        output1.Add(output2.ElementAt(j) + c.ToString());
                    }
                }
               
            }
            return output1;
        }
 
        
        */
    }
}
