using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoE
{
    public class LongestWordFinder
    {
        public void FindLongestWord(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            // Read content of the file
            string content = File.ReadAllText(filePath);

            // Split content into words
            string[] words = content.Split(new char[] { ' ', '\n', '\r', '\t', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            // Find the longest word
            string longestWord = words.OrderByDescending(word => word.Length).FirstOrDefault();

            Console.WriteLine($"Longest word: {longestWord}");
        }
    }
}
