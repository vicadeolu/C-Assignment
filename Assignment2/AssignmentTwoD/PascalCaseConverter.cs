using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoD
{
    public class PascalCaseConverter
    {
        public void ConvertToPascalCase()
        {
            Console.Write("Enter words separated by spaces (e.g., 'number of students'): ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            // Convert to PascalCase
            var pascalCase = string.Join("", input
                .ToLower()
                .Split(' ')
                .Select(word => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word)));

            Console.WriteLine($"PascalCase: {pascalCase}");
        }
    }
}
