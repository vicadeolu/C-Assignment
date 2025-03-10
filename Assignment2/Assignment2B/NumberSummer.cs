using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoB
{
    public class NumberSummer
    {
        // Continuously asks the user to enter a number or "ok" to exit and calculates the sum
        public void CalculateSum()
        {
            int sum = 0;
            while (true)
            {
                Console.Write("Enter a number (or 'ok' to exit): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "ok")
                {
                    break;
                }

                sum += Convert.ToInt32(input);
            }

            Console.WriteLine($"The total sum of the entered numbers is: {sum}");
        }
    }
}
