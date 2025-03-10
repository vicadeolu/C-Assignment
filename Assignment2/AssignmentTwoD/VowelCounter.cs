using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoD
{
    public class VowelCounter
    {
        public void CountVowels()
        {
            Console.Write("Enter an English word: ");
            string input = Console.ReadLine().ToLower(); // Normalize to lowercase

            // Define vowels
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            // Count vowels in the input
            int vowelCount = input.Count(c => vowels.Contains(c));

            Console.WriteLine($"Number of vowels: {vowelCount}");
        }
    }
}
