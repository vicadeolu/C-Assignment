using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoD
{
    public class TimeValidator
    {
        public void ValidateTime()
        {
            Console.Write("Enter a time (24-hour format e.g., 19:00): ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) || !IsValidTime(input))
            {
                Console.WriteLine("Invalid Time");
                return;
            }

            Console.WriteLine("Ok");
        }

        private bool IsValidTime(string time)
        {
            var parts = time.Split(':');
            if (parts.Length != 2) return false;

            bool isValidHours = int.TryParse(parts[0], out int hours) && hours >= 0 && hours <= 23;
            bool isValidMinutes = int.TryParse(parts[1], out int minutes) && minutes >= 0 && minutes <= 59;

            return isValidHours && isValidMinutes;
        }
    }
}
