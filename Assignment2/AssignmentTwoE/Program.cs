using System;
using AssignmentTwoE;

class Program
{
    static void Main()
    {
        try
        {
            /// Path to the sample text file 
            string filePath = "./Files/Document.txt";

            /// Count words in a file
            var wordCounter = new WordCounter();
            wordCounter.CountWords(filePath);

            ///Find the longest word in a file
            var longestWordFinder = new LongestWordFinder();
            longestWordFinder.FindLongestWord(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
