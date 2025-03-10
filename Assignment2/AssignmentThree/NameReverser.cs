using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoC
{
    public class NameReverser
    {
        public void ReverseAndDisplay()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            // Reverse the name using an array
            char[] nameArray = name.ToCharArray();
            Array.Reverse(nameArray);

            string reversedName = new string(nameArray);
            Console.WriteLine($"Reversed name: {reversedName}");
        }
    }
}
