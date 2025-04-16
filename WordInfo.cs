using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa
{
    class WordInfo
    {
        // The actual word.
        public string Word { get; private set; }
        // The number of times the word has been encountered.
        public int Count { get; set; }
        // A list of line numbers where the word appears.
        public List<int> LineNums { get; private set; }

        /// <summary>
        /// Creates an object that store the word, its count and a list of the line number it appears in.
        /// </summary>
        /// <param name="word">The word.</param>
        public WordInfo(string word)
        {
            Word = word;
            Count = 1;
            LineNums = new List<int>();
        }

        /// <summary>
        /// Increase the count variable and adds the line number to the LineNums list.
        /// </summary>
        /// <param name="linenum">The Line number.</param>
        public void AddInstance(int linenum)
        {
            Count++;
            LineNums.Add(linenum);
        }
    }
}
