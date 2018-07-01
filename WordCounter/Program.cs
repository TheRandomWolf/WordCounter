using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			string[] splitInput = input.Split(' ');
			for(int i = 0; i < splitInput.Length; i++)
			{
				splitInput[i] = StripPunctuation(splitInput[i]);
			}
			Dictionary<string, int> countedWords = CountWords(splitInput);
			List<string> formattedCountedWords = FormatData(countedWords);
			foreach (string s in formattedCountedWords) Console.WriteLine(s);
			Console.ReadKey();
		}
		static Dictionary<string, int> CountWords(string[] wordArray)
		{
			Dictionary<string, int> wordsCount = new Dictionary<string, int>();
			foreach (string s in wordArray)
			{
				if (wordsCount.ContainsKey(s.ToLower())) wordsCount[s]++;
				else wordsCount.Add(s.ToLower(), 1);
			}
			return wordsCount;
		}
		static List<String> FormatData(Dictionary<string, int> dictionary)
		{
			List<String> wordCounts = new List<string>();
			foreach(KeyValuePair<string, int> word in dictionary)
			{
				string entry = string.Format("The word '{0}' appears {1} times in this text", word.Key, word. Value);
				wordCounts.Add(entry);
			}
			return wordCounts;
		}
		static string StripPunctuation(string punctuatedString)
		{
			StringBuilder sb = new StringBuilder();
			char[] punctuatedCharArray = punctuatedString.ToCharArray();
			foreach (char c in punctuatedCharArray)
			{
				if (!char.IsPunctuation(c)) sb.Append(c);
			}
			return sb.ToString();
		}
	}
}
