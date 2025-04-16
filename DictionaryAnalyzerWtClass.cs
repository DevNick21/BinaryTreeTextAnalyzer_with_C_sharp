using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa
{
    class DictionaryAnalyzerWtClass
    {
        private Dictionary<string, WordInfo> wordData;

        public DictionaryAnalyzerWtClass()
        {
            wordData = new Dictionary<string, WordInfo>();
        }

        /// <summary>
        /// Inserts a word into the dictionary. If the word already exists,
        /// updates its count and adds the new line number. Otherwise, creates a new entry.
        /// </summary>
        /// <param name="word">The word to insert.</param>
        /// <param name="lineNumber">The line number where the word was found.</param>
        public void InsertWord(string word, int lineNum)
        {
            if (wordData.ContainsKey(word))
            {
                wordData[word].AddInstance(lineNum);
            }
            else
            {
                // Create a new WordInfo object and add the line number and add to wordData dict
                WordInfo newWordInfo = new WordInfo(word);
                newWordInfo.LineNums.Add(lineNum);
                wordData[word] = newWordInfo;
            }
        }
        /// <summary>
        /// Displays the total number of unique words found.
        /// </summary>
        public void DisplayUniqueWordCount()
        {
            Console.WriteLine($"Unique words: {wordData.Count}");
        }

        /// <summary>
        /// Displays all the words.
        /// </summary>
        public void DisplayAllWords()
        {
            foreach(var word_entry in wordData)
            {
                WordInfo word_info = word_entry.Value;
                Console.WriteLine($"Word: {word_info.Word}, Occurrences: {word_info.Count}");
            }
        }
        /// <summary>
        /// Displays the word that appears the most.
        /// </summary>
        public void DisplayMostFrequentWord()
        {
            if (wordData.Count == 0)
            {
                Console.WriteLine("No words found");
                return;
            }
            WordInfo mostFrequent = null;
            foreach(var word_entry in wordData)
            {
                if (mostFrequent == null || word_entry.Value.Count > mostFrequent.Count)
                {
                    mostFrequent = word_entry.Value;
                }
            }
            Console.WriteLine($"The Most Frequent Word is \"{mostFrequent.Word}\" with ({mostFrequent.Count}) occurrences");
        }
        /// <summary>
        /// Displays the longest word in the file.
        /// </summary>
        public void DisplayLongestWord()
        {
            if (wordData.Count == 0)
            {
                Console.WriteLine("No words found");
                return;
            }
            WordInfo longestWord = null;
            foreach (var word_entry in wordData)
            {
                if (longestWord == null || word_entry.Value.Word.Length > longestWord.Word.Length)
                {
                    longestWord = word_entry.Value;
                }
            }
            Console.WriteLine($"The Longest Word is \"{longestWord.Word}\" with ({longestWord.Word.Length}) length and ({longestWord.Count}) occurrences");
        }
    }
}
