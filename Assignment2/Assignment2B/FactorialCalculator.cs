using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoB
{
    public class FactorialCalculator
    {
        // Returns the factorial of a number
        public int GetFactorial(int number)
        {
            if (number < 0)
                throw new ArgumentException("Factorial is not defined for negative numbers.");

            int factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
