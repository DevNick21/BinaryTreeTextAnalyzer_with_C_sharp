using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa
{
    // Main class for individual nodes in the binary tree, Contains the WordInfo object and two objects of itself which are the left and right Nodes
    class NodeTree
    {
        // The WordInfo object in the DSA namespace, It hold the word and its data
        public WordInfo Data { get; set; }
            
        // Pointer to the left child (words that come before alphabetically)
        public NodeTree Left { get; set; }
            
        // Pointer to the Right child (words that come before alphabetically)
        public NodeTree Right { get; set; }

        /// <summary>
        /// A Constructor that initializes this node with a word class and adds the line number to the WordInfo attribute:"LineNums"
        /// </summary>
        /// <param name="word">The word.</param>
        /// <param name="lineNumber">The Line number.</param>
        public NodeTree(string word, int lineNumber)
        {
            Data = new WordInfo(word);
            Data.LineNums.Add(lineNumber);
        }
     
    }
}
