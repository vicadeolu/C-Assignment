using System;
using AssignmentTwoC;
// Import custom classes

class Program
{
    static void Main()
    {
        try
        {

            // Facebook-like message
            var facebookLikeDisplay = new FaceBookLikes();
            facebookLikeDisplay.ShowLikes();
            //// Reverse name
            var nameReverser = new NameReverser();
            nameReverser.ReverseAndDisplay();

            Console.WriteLine();

            /// Collect and sort 5 unique numbers
            var uniqueNumberCollector = new UniqueNumCollector();
            uniqueNumberCollector.CollectAndDisplay();

            Console.WriteLine();

            /// Display unique numbers
            var uniqueNumberLister = new UniqueNumLister();
            uniqueNumberLister.ListUniqueNumbers();

            Console.WriteLine();

            /// Find the 3 smallest numbers
            var smallestNumbersFinder = new SmallestNumberFinder();
            smallestNumbersFinder.FindAndDisplaySmallestNumbers();


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
