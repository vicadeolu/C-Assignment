using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoA
{
    public class ValidateNumbers
    {
        public bool IsValid(int number, out string message)
        {
            if (number < 1 || number > 10)
            {
                message = "Number is not between 1 and 10";
                return false;
            }
            message = string.Empty;
            return number >= 1 && number <= 10;
        }
        
    }
}
