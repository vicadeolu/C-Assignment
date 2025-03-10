using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoC
{
    public class UniqueNumCollector
    {
        public void CollectAndDisplay()
        {
            var numbers = new HashSet<int>();

            while (numbers.Count < 5)
            {
                Console.Write("Enter a unique number: ");
                int number = Convert.ToInt32(Console.ReadLine());

                if (!numbers.Add(number))
                {
                    Console.WriteLine("Error: Number already entered. Try again.");
                }
            }

            var sortedNumbers = numbers.OrderBy(n => n).ToList();
            Console.WriteLine("Sorted unique numbers: " + string.Join(", ", sortedNumbers));
        }
    }
}
