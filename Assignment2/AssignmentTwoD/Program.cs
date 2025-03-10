using System;
using AssignmentTwoD;

class Program
{
    static void Main()
    {
        try
        {

            ///  Check for consecutive numbers
            var consecutiveChecker = new ConsecutiveDetector();
            consecutiveChecker.CheckConsecutive();

            Console.WriteLine();

            /// Check for duplicate numbers
            var duplicateChecker = new DuplicateChecker();
            duplicateChecker.CheckDuplicates();

            Console.WriteLine();

            /// Validate 24-hour time format
            var timeValidator = new TimeValidator();
            timeValidator.ValidateTime();

            Console.WriteLine();

            /// Convert words to PascalCase
            var pascalCaseConverter = new PascalCaseConverter();
            pascalCaseConverter.ConvertToPascalCase();

            /// Count vowels in a string
            var vowelCounter = new VowelCounter();
            vowelCounter.CountVowels();


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
