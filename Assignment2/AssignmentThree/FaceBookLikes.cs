using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoC
{
    public class FaceBookLikes
    {
        // Continuously prompts the user for names and displays the appropriate like message
        public void ShowLikes()
        {
            var names = new List<string>();

            Console.WriteLine("Enter names (press Enter to finish):");

            while (true)
            {
                string input = Console.ReadLine();

                // Stop when the user presses Enter without input
                if (string.IsNullOrWhiteSpace(input))
                    break;

                names.Add(input);
            }

            // Generate the appropriate message based on the number of names
            if (names.Count == 1)
            {
                Console.WriteLine($"{names[0]} likes your post.");
            }
            else if (names.Count == 2)
            {
                Console.WriteLine($"{names[0]} and {names[1]} like your post.");
            }
            else if (names.Count > 2)
            {
                Console.WriteLine($"{names[0]}, {names[1]} and {names.Count - 2} others like your post.");
            }
            else
            {
                Console.WriteLine("No likes yet.");
            }
        }
    }
}
