using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoD
{
    public class ConsecutiveDetector
    {
        public void CheckConsecutive()
        {
            Console.Write("Enter numbers separated by hyphen (e.g., 5-6-7-8): ");
            string input = Console.ReadLine();

            var numbers = input.Split('-')
                               .Select(int.Parse)
                               .ToList();

            bool isAscending = numbers.Zip(numbers.Skip(1), (a, b) => b - a).All(diff => diff == 1);
            bool isDescending = numbers.Zip(numbers.Skip(1), (a, b) => a - b).All(diff => diff == 1);

            Console.WriteLine(isAscending || isDescending ? "Consecutive" : "Not Consecutive");
        }
    }
}
