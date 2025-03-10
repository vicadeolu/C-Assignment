using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoE
{
    public class WordCounter
    {
        public void CountWords(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            // Read the content of the file
            string content = File.ReadAllText(filePath);

            // Split content by whitespace to get words
            string[] words = content.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($"Total number of words: {words.Length}");
        }
    }
}
