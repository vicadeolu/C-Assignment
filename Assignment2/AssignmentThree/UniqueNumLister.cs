using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoC
{
    public class UniqueNumLister
    {
        public void ListUniqueNumbers()
        {
            var numbers = new List<int>();

            while (true)
            {
                Console.Write("Enter a number (or 'Quit' to exit): ");
                string input = Console.ReadLine();

                if (input.Equals("Quit", StringComparison.OrdinalIgnoreCase))
                    break;

                numbers.Add(Convert.ToInt32(input));
            }

            var uniqueNumbers = numbers.Distinct();
            Console.WriteLine("Unique numbers: " + string.Join(", ", uniqueNumbers));
        }
    }
}
