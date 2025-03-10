using AssignmentTwoB;
using static AssignmentTwoB.Counter;

namespace CSharpAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Count numbers divisible by 3
            var divisibleCounter = new DivisibleCounter();
            int count = divisibleCounter.CountDivisibleByThree(1, 100);
            Console.WriteLine($"Numbers between 1 and 100 divisible by 3: {count}");

            Console.WriteLine();

            //  Sum numbers until "ok"
            var numberSummer = new NumberSummer();
            numberSummer.CalculateSum();

            /// <summary>
            ///     Get Factorial

            Console.Write("Enter a number to compute the factorial: ");
            int factorialInput = Convert.ToInt32(Console.ReadLine());

            var factorialCalculator = new FactorialCalculator();
            long factorialResult = factorialCalculator.GetFactorial(factorialInput);
            Console.WriteLine($"{factorialInput}! = {factorialResult}");

            Console.WriteLine();

            /// <summary>
            /// Random number guessing game (1-10)
            var guessingGame = new GuessNow();
            guessingGame.Play();

            Console.WriteLine();

            /// <summary>
            /// Get the maximum number from a series
            Console.Write("Enter a series of numbers separated by commas: ");
            string inputSeries = Console.ReadLine();

            var maxFromSeries = new MaxNumberInSeries();
            int maxNumber = maxFromSeries.FindMax(inputSeries);
            Console.WriteLine($"The maximum number is: {maxNumber}");




        }
    }
}