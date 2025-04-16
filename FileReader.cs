using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace dsa
{
    public class FileReader
    {
        private readonly char[] delimiters = { ' ', ',', '"', ':', ';', '?', '!', '-', '.', '\'', '*' };

        /// <summary>
        /// Checks if a given string is a valid word using a regular expression.
        /// </summary>
        /// <param name="str">The token to check.</param>
        /// <returns>Regular Expressions boolean result: True if it is a word; otherwise, false. For the Process Word method</returns>
        private bool IsWord(string str)
        {
            // This regex matches words with at least two letters or the single letters "a" or "i".
            return Regex.IsMatch(str, @"\b(?:[a-z]{2,}|[ai])\b", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Reads the file specified by filePath and processes each valid word using the provided callback.
        /// </summary>
        /// <param name="filePath">Path to the text file.</param>
        /// <param name="processWord">A callback method that takes a word and its line number.</param>
        public void ReadFile(string filePath, Action<string, int> processWord)
        {
            string[] lines = File.ReadAllLines(filePath);
            int lineNum = 0;
            foreach (string line in lines)
            {
                lineNum++;  


                string[] wordsInLine = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in wordsInLine)
                {
                    if (IsWord(word))
                    {
                        // Processes each valid word by converting to lowercase and providing the line number.
                        processWord(word.ToLower(), lineNum);
                    }

                }
            }
        }
    }
}
