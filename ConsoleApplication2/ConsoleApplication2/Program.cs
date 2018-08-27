using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSpell.SpellChecker.Dictionary;
using NetSpell.SpellChecker; 
namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");

            WordDictionary oDict = new WordDictionary();

            oDict.DictionaryFile = "en-US.dic";
            oDict.Initialize();
            string wordToCheck = "door";
            Spelling oSpell = new Spelling();
            oSpell.Dictionary = oDict;

            if (!oSpell.TestWord(wordToCheck))
            {
                Console.WriteLine("Word does not exist"); 
            } else
            {
                Console.WriteLine("Word exists");
            }
            Console.ReadLine(); 
        }


        public List<string> GetAllPossibleWordsOfGivenLength(string inputText, int requiredLength)
        {
            List<string> listOfWords = new List<string>();
            if (requiredLength > inputText.Length)
            {
                Console.WriteLine("Error.. required length can not be more than length of given string");
                return null; 
            }
            if (inputText.Length == 0)
            {
                return null; 
            }
            if (inputText.Length == 1 && requiredLength == 1)
            { 
                listOfWords.Add(inputText); 
                return listOfWords; 
            } else
            {
                foreach(char c in inputText.ToCharArray())
                {

                }
            }



            return listOfWords; 
        }


    }
}
