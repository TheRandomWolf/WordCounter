using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WordCounter
{
    public class Counter
    {
		protected string[] text;
		protected Dictionary<string, int> wordsCount;
		public Counter(string input, bool isPath)
		{
			if (isPath) text = File.ReadAllText(input).Split(' ');
			else text = input.Split(' ');
			text = StripPunctuation(text);
			wordsCount = CountWords(text);
		}
		Dictionary<string, int> CountWords(string[] wordArray)
		{
			Dictionary<string, int> wordsCount = new Dictionary<string, int>();
			foreach (string s in wordArray)
			{
				if (wordsCount.ContainsKey(s.ToLower())) wordsCount[s.ToLower()]++;
				else wordsCount.Add(s.ToLower(), 1);
			}
			return wordsCount;
		}
		public int GetWordCount(string word)
		{
			if (wordsCount.ContainsKey(word)) return wordsCount[word];
			else return 0;
		}
		public Dictionary<string, int> GetWordsCount(string[] words)
		{
			Dictionary<string, int> result = new Dictionary<string, int>();
			foreach (string s in words)
			{
				wordsCount.TryGetValue(s, out int value);
				result.Add(s, value);
			}
			return result;
		}
		public Dictionary<string,int> GetAllCount()
		{
			return wordsCount;
		}
		string[] StripPunctuation(string[] splitInput)
		{
			for (int i = 0; i < splitInput.Length; i++)
			{
				splitInput[i] = StripPunctuation(splitInput[i]);
			}
			return splitInput;
		}
		string StripPunctuation(string punctuatedString)
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
