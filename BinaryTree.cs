using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dsa
{
    class BinaryTree
    {
        private NodeTree root;

        // Binary Tree Constructor with root set to null
        public BinaryTree()
        {
            root = null;
        }

        /// <summary>
        /// A method to insert a word into the binary tree, using the Insert Node method
        /// </summary>
        /// <param name="word"> The word to insert</param>
        /// <param name="lineNumber">The Line number to insert</param>
        public void InsertWord(string word, int lineNumber)
        {
            root = InsertNode(root, word, lineNumber);
        }

        /// <summary>
        /// Helper method to recursively insert a new word into the tree, based off its alphabetical orderd or if the word exists,
        /// so it recursively adds to the current's left or right given that condition till it finds a point where it possibly put in the last node,
        /// where it then puts the 
        /// 
        /// </summary>
        private NodeTree InsertNode(NodeTree current, string word, int lineNumber)
        {
            if (current == null)
            {
                // No node exists here, so create a new one.
                return new NodeTree(word, lineNumber);
            }

            // Compare the words in a case-insensitive manner.
            int check = string.Compare(word, current.Data.Word, StringComparison.OrdinalIgnoreCase);

            if (check == 0)
            {
                // Word already exists; update its data.
                current.Data.AddInstance(lineNumber);
            }
            else if (check < 0)
            {
                // Word is lexically less -> go to the left subtree.
                current.Left = InsertNode(current.Left, word, lineNumber);
            }
            else
            {
                // Word is lexically greater -> go to the right subtree.
                current.Right = InsertNode(current.Right, word, lineNumber);
            }

            return current;
        }
        /// <summary>
        /// Performs an in-order traversal of the tree, printing each node's data.
        /// Where it goes left, until node is null then prints the node and then goes right till right is null and ends the recursion.
        /// (The processing of the nodes is recursive as the function (method) calls itself.
        /// </summary>
        /// <param name="node">Current node in the traversal.</param>
        private void InOrderTraversal(NodeTree node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.WriteLine($"Word: \"{node.Data.Word}\", Count: {node.Data.Count}, Lines: {string.Join(", ", node.Data.LineNums)}");
                InOrderTraversal(node.Right);
            }
        }

        /// <summary>
        /// Displays all words in the binary tree in alphabetical order (In-order) of cause it was store in alphabetical order
        /// </summary>
        public void DisplayAllWords()
        {
            InOrderTraversal(root);
        }



        /// <summary>
        /// Performs an PreOrder traversal of the tree, printing each node's data.
        /// Where it prints the root then goes left and prints then right and prints until a node is null and ends the recursion.
        /// (The processing of the nodes is recursive as the function (method) calls itself.
        /// </summary>
        /// <param name="node">Current node in the traversal.</param>
        private void PreOrderTraversal(NodeTree node)
        {
            if (node != null)
            {
                Console.WriteLine($"Word: \"{node.Data.Word}\", Count: {node.Data.Count}, Lines: {string.Join(", ", node.Data.LineNums)}");
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }
        }

        /// <summary>
        /// Displays all words in the binary tree in No order.
        /// </summary>
        public void DisplayAllWordsNoOrder()
        {
            PreOrderTraversal(root);
        }

        /// <summary>
        /// Displays the number of unique words as a result of the calling the recursive CountNodes function(method) on the root hence iniatiating the recursion.
        /// </summary>
        public void DisplayUniqueWordCount()
        {
            int count = CountNodes(root);
            Console.WriteLine($"Unique words: {count}");
        }

        /// <summary>
        /// Counts the number of unique words by recursively counting tree nodes.
        /// Where it adds the 1 for each node it counts and the function(method) calls itself on both left or right while checking if the left or right is null,
        /// if false it repeats the process till it finds leaf nodes.
        /// </summary>
        /// <param name="node">Current node in the traversal.</param>
        /// <returns>The number of nodes as an integer</returns>
        private int CountNodes(NodeTree node)
        {
            if (node == null)
                return 0;
            else
                return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }



        /// <summary>
        /// Finds and displays the most frequent word in the tree by the calling the recursive FindLongestWord function(method) on the root hence initiating the recursion.
        /// </summary>
        public void DisplayLongestWord()
        {
            if (root == null)
            {
                Console.WriteLine("No words found.");
                return;
            }
            WordInfo longest = FindLongestWord(root);
            Console.WriteLine($"Longest Word: \"{longest.Word}\" ({longest.Count} occurrences)");
        }

        /// <summary>
        /// Recursive method to find the node containing the longest word.
        /// Where it starts from root and recursively calls itself on the child nodes till it finds a null (empty branch) as the recursion unwinds it then compares the child nodes results with its parent and gets the longest word, 
        /// does this till it gets to the root where it would have explored every child nodes and leaf
        /// </summary>
        /// <params name="node"></params>
        private WordInfo FindLongestWord(NodeTree node)
        {
            if (node == null)
                return null;

            WordInfo longest = node.Data;

            WordInfo leftLongest = FindLongestWord(node.Left);
            WordInfo rightLongest = FindLongestWord(node.Right);

            if (leftLongest != null && leftLongest.Word.Length > longest.Word.Length)
                longest = leftLongest;
            if (rightLongest != null && rightLongest.Word.Length > longest.Word.Length)
                longest = rightLongest;

            return longest;
        }

        /// <summary>
        /// Finds and displays the most frequent word in the tree by the calling the recursive GetMostFrequent function(method) on the root hence iniatiating the recursion.
        /// </summary>
        public void DisplayMostFrequentWord()
        {
            if (root == null)
            {
                Console.WriteLine("No words found.");
                return;
            }
            WordInfo mostFrequent = GetMostFrequent(root);
            Console.WriteLine($"Most Frequent Word: \"{mostFrequent.Word}\" ({mostFrequent.Count} occurrences)");
        }

        /// <summary>
        /// Recursive method to find the node with the highest count.
        /// Where it starts from root and recursively calls itself on the child nodes till it finds a null (empty branch) as the recursion unwinds it then compares the child nodes results with its parent and gets the most, 
        /// does this till it gets to the root where it would have explored every child nodes and leaf.
        /// </summary>
        /// <params name="node"></params>
        private WordInfo GetMostFrequent(NodeTree node)
        {
            if (node == null)
                return null;

            WordInfo most = node.Data;

            WordInfo leftMost = GetMostFrequent(node.Left);
            WordInfo rightMost = GetMostFrequent(node.Right);

            if (leftMost != null && leftMost.Count > most.Count)
                most = leftMost;
            if (rightMost != null && rightMost.Count > most.Count)
                most = rightMost;

            return most;
        }

        /// <summary>
        /// Finds and displays the Line numbers for a word using the recursive FindWord method, triggering it from the root.
        /// </summary>
        /// <param name="word">The word to be found</param>
        public void DisplayLineNumsOfWord(string word)
        {
            WordInfo result = FindWord(root, word);
            if (result != null)
            {
                Console.WriteLine($"The word \"{word}\" was found on line(s): {string.Join(", ", result.LineNums)}");
            }
            else
            {
                Console.WriteLine($"The word \"{word}\" was not found in the file.");
            }
        }


        /// <summary>
        /// Finds and displays the Line numbers for a word using the recursive FindWord method, triggering it from the root.
        /// </summary>
        /// <param name="word">The word to be found</param>
        public void DisplayFrequencyOfWord(string word)
        {
            WordInfo result = FindWord(root, word);
            if (result != null)
            {
                Console.WriteLine($"The word \"{word}\" was found with {result.Count} occurrences");
            }
            else
            {
                Console.WriteLine($"The word \"{word}\" was not found in the file.");
            }
        }
        /// <summary>
        /// Find the word by recursively checking the left and right against the word until the string method return "0" which means there isn't any difference, hence the words are the same.
        /// Can be reused to find any info about a word.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="word"></param>
        /// <returns>The word found</returns>
        private WordInfo FindWord(NodeTree current, string word)
        {
            if (current == null)
                return null;

            int comp = string.Compare(word, current.Data.Word, StringComparison.OrdinalIgnoreCase);
            if (comp == 0)
            {
                return current.Data;
            }
            else if (comp < 0)
            {
                return FindWord(current.Left, word);
            }
            else
            {
                return FindWord(current.Right, word);
            }
        }

    }
}
