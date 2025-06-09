# Text Analysis Tool using Binary Search Tree (BST)

This is a modular C# console application that reads a text file and analyses the words using a Binary Search Tree. It tracks word frequencies, the lines they appear on, and supports sorted and unsorted output. It was designed to demonstrate practical data structure implementation, particularly the Binary Search Tree, while reflecting on alternatives like Dictionaries, Linked Lists, and Static Arrays.

---

## 🔧 Features

- Read and parse words from a `.txt` file
- Track each word’s frequency and the line numbers where it appears
- Case-insensitive, regex-filtered word matching
- Display:
  - All words (sorted or unsorted)
  - The most frequent word
  - The longest word
  - Line numbers for a specific word
  - Frequency for a specific word
- Uses a modular design with core components: `FileReader`, `WordInfo`, `BinaryTree`, `NodeTree`, and `MenuHandler`

---

## 📂 Structure

```bash
/ProjectRoot
│
├── FileReader.cs        # Handles file parsing and word extraction
├── WordInfo.cs          # Represents a word, its frequency, and line numbers
├── NodeTree.cs          # Single node in the binary tree
├── BinaryTree.cs        # Handles insertion and traversal logic
├── MenuHandler.cs       # Displays the console menu and user interaction
├── Program.cs           # Entry point
├── sherlockHolmes.txt   # Sample input file
└── mobydick.txt         # Second input file for analysis
