using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace dsa
{
    class Menu
    {
        // Handles everything on the console app
        public class MenuHandler
        {
            // A dictionary that maps command strings to its methods.
            private readonly Dictionary<string, Action> commands;
            // BinaryTree which would be used all through the class
            private BinaryTree textAnalyzer;
            // The two text file given for analysis
            private readonly string fileSherlock = "sherlockHolmes.txt";
            private readonly string fileMoby = "mobydick.txt";

            public MenuHandler()
            {
                // The dictionary of commands in order of the question asked
                commands = new Dictionary<string, Action>
            {
                { "1", BuildAndStoreWords },
                { "2", DisplayUniqueWordCount },
                { "3", BuildAndStoreWords },
                { "4", DisplayAllWordsUnsorted },
                { "5", DisplayAllWordsSorted },
                { "6", DisplayLongestWord },
                { "7", DisplayMostFrequentWord },
                { "8", DisplayLineNumbersForSpecificWord },
                { "9", DisplayFrequencyForSpecificWord },
                { "0", ExitApp }
            };
                Stopwatch stopwatch = Stopwatch.StartNew();
                BuildAndStoreWords();
                stopwatch.Stop();
                Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
            }

            // This method runs the menu loop, reading input and dispatching the command.
            public void Run()
            {
                while (true)
                {
                    DisplayMenu();
                    string choice = Console.ReadLine();
                    if (commands.ContainsKey(choice))
                    {
                        commands[choice].Invoke();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please choose a number from 0 to 9.");
                    }
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                }
            }

            // Displays the menu options.
            private void DisplayMenu()
            {
                Console.WriteLine("\nText Analysis Tool:");
                Console.WriteLine("Choose an option (1-9):");
                Console.WriteLine("1. Build and Store Unique Words");
                Console.WriteLine("2. Display Unique Word Count");
                Console.WriteLine("3. Store Number of occurences");
                Console.WriteLine("4. Display All Words (Unsorted)");
                Console.WriteLine("5. Display All Words (Sorted)");
                Console.WriteLine("6. Display Longest Word and Count");
                Console.WriteLine("7. Display Most Frequent Word and Count");
                Console.WriteLine("8. Display Line Numbers for a Specific Word");
                Console.WriteLine("9. Display Frequency for a Specific Word");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
            }

            /// <summary>
            /// Main method to build binary Tree, prompts user to choose between two text file and read, build, store the words into a binary tree
            /// </summary>
            private void BuildAndStoreWords()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("Hi, Press \"s\" for sherlockHomes or \"m\" for MobyDick..");
                    string text = Console.ReadLine().ToLower();
                    if (text == "s")
                    {
                        Console.WriteLine("Building and storing unique words...");
                        FileReader fileReader = new FileReader();
                        textAnalyzer = new BinaryTree();
                        void ProcessWord(string word, int lineNumber)
                        {
                            textAnalyzer.InsertWord(word, lineNumber);
                        }

                        fileReader.ReadFile(fileSherlock, ProcessWord);
                        exit = true;
                    }
                    else if (text == "m")
                    {
                        Console.WriteLine("Building and storing unique words...");
                        FileReader fileReader = new FileReader();
                        textAnalyzer = new BinaryTree();
                        void ProcessWord(string word, int lineNumber)
                        {
                            textAnalyzer.InsertWord(word, lineNumber);
                        }

                        fileReader.ReadFile(fileMoby, ProcessWord);
                        exit = true;
                    }
                    else if (text == "0")
                    {
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a correct option or \"0\" to go back to main menu...");
                    }
                }

            }
            /// <summary>
            /// Function to trigger unique word count method
            /// </summary>
            private void DisplayUniqueWordCount()
            {
                Console.WriteLine("Displaying unique word count...");
                textAnalyzer.DisplayUniqueWordCount();

            }
            /// <summary>
            /// Function to trigger the preorder method
            /// </summary>
            private void DisplayAllWordsUnsorted()
            {
                Console.WriteLine("Displaying all words (unsorted)...");
                textAnalyzer.DisplayAllWordsNoOrder();

            }
            /// <summary>
            /// Function to trigger the in-order method
            /// </summary>
            private void DisplayAllWordsSorted()
            {
                Console.WriteLine("Displaying all words (sorted)...");
                textAnalyzer.DisplayAllWords();

            }
            /// <summary>
            /// Function to trigger display longest word method
            /// </summary>
            private void DisplayLongestWord()
            {
                Console.WriteLine("Displaying the longest word and its count...");
                textAnalyzer.DisplayLongestWord();

            }
            /// <summary>
            /// Function to trigger display most frequent word method
            /// </summary>
            private void DisplayMostFrequentWord()
            {
                Console.WriteLine("Displaying the most frequent word and its count...");
                textAnalyzer.DisplayMostFrequentWord();

            }
            /// <summary>
            /// Function to trigger display specific word line numbers method
            /// </summary>
            private void DisplayLineNumbersForSpecificWord()
            {
                Console.Write("Enter the word to search for its line numbers: ");
                string word = Console.ReadLine();
                Console.WriteLine($"(Would display line numbers for \"{word}\")");
                textAnalyzer.DisplayLineNumsOfWord(word);

            }
            /// <summary>
            /// Function to trigger display specific word and its frequency method
            /// </summary>
            private void DisplayFrequencyForSpecificWord()
            {
                Console.Write("Enter the word to search for its frequency: ");
                string word = Console.ReadLine();
                Console.WriteLine($"(Would display frequency for \"{word}\")");
                textAnalyzer.DisplayFrequencyOfWord(word);

            }
            /// <summary>
            /// Function to quit loop
            /// </summary>
            private void ExitApp()
            {
                Environment.Exit(0);
            }
        }
    }
}
