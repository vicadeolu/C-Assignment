using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoC
{
    public class SmallestNumberFinder
    {
        public void FindAndDisplaySmallestNumbers()
        {
            while (true)
            {
                Console.Write("Enter a list of comma-separated numbers: ");
                string input = Console.ReadLine();

                var numbers = input.Split(',')
                                   .Select(n => Convert.ToInt32(n.Trim()))
                                   .ToList();

                if (numbers.Count < 5)
                {
                    Console.WriteLine("Invalid List. Please enter at least 5 numbers.");
                    continue;
                }

                // Find the 3 smallest numbers
                var smallestNumbers = numbers.OrderBy(n => n).Take(3);
                Console.WriteLine("The 3 smallest numbers: " + string.Join(", ", smallestNumbers));
                break;
            }
        }
    }
}
