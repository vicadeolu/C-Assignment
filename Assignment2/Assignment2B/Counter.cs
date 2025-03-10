using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoB
{
    public class Counter
    {
        public class DivisibleCounter
        {
            // Counts how many numbers between start and end are divisible by 3
            public int CountDivisibleByThree(int start, int end)
            {
                int count = 0;
                for (int i = start; i <= end; i++)
                {
                    if (i % 3 == 0)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
    }
}
