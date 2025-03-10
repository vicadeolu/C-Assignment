using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoD
{
    public class DuplicateChecker
    {
        public void CheckDuplicates()
        {
            Console.Write("Enter numbers separated by hyphen (e.g., 1-2-3-4): ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                return; // Exit if input is empty

            var numbers = input.Split('-')
                               .Select(int.Parse)
                               .ToList();

            var hasDuplicates = numbers.Count != numbers.Distinct().Count();

            Console.WriteLine(hasDuplicates ? "Duplicate" : "No Duplicates");
        }
    }
}
