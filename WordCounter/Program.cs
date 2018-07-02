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
			Console.WriteLine("Please choose between inserting a path and inputting text directly. Text/Path");
			string choice = Console.ReadLine();
			string input = string.Empty;
			switch (choice.ToLower())
			{
				case "path":
					Console.Write("Path: ");
					string path = Console.ReadLine();
					input = System.IO.File.ReadAllText(@path);
					break;
				case "text":
					Console.Write("Text: ");
					input = Console.ReadLine();
					break;
				default:
					Console.WriteLine("Invalid input. Please try again and only type in 'text' or 'path'");
					Console.WriteLine("Press any key to exit.");
					Console.ReadKey();
					Environment.Exit(0);
					break;
			}
			string[] splitInput = input.Split(' ');
			StripPunctuation(splitInput);
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
				if (wordsCount.ContainsKey(s.ToLower())) wordsCount[s.ToLower()]++;
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
		static string[] StripPunctuation(string[] splitInput)
		{
			for (int i = 0; i < splitInput.Length; i++)
			{
				splitInput[i] = StripPunctuation(splitInput[i]);
			}
			return splitInput;
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
