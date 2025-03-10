using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoB
{
    public class GuessNow
    {
        public void Play()
        {
            Random random = new Random();
            int secretNumber = random.Next(1, 11); // Random number between 1 and 10
            Console.WriteLine($"(Secret number for testing: {secretNumber})");

            int attempts = 4;

            for (int i = 0; i < attempts; i++)
            {
                Console.Write("Guess the number (between 1 and 10): ");
                int guess = Convert.ToInt32(Console.ReadLine());

                if (guess == secretNumber)
                {
                    Console.WriteLine("You won!");
                    return;
                }
            }

            Console.WriteLine("You lost!");
        }
    }
}
