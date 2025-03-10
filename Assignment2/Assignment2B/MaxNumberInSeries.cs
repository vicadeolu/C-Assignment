using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoB
{
    public class MaxNumberInSeries
    {
        // Finds the maximum number from a comma-separated series of numbers
        public int FindMax(string input)
        {
            // Split the input by commas and parse each number
            var numbers = input.Split(',').Select(int.Parse).ToArray();
            return numbers.Max();
        }
    }
}
