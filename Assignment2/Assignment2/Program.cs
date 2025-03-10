using AssignmentTwoA;

namespace CSharpAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number between 1 and 10: ");
            int number = Convert.ToInt32(Console.ReadLine());
            var validator = new ValidateNumbers();
            if (validator.IsValid(number, out string message))
            {
                Console.WriteLine("Number is valid");
            }
            else
            {
                Console.WriteLine(message);
            }

            /// <summary>
            /// Get Max number
            Console.Write("Enter the first number: ");
            int number1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int number2 = Convert.ToInt32(Console.ReadLine());

            var calculator = new MaxNumber();
            int max = calculator.GetMax(number1, number2);
            Console.WriteLine($"The maximum number is: {max}");

            /// <summary>
            /// Get image shape from sizes

            Console.Write("Enter image width: ");
            int width = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter image height: ");
            int height = Convert.ToInt32(Console.ReadLine());

            var imageAnalyzer = new ShapeDetector();
            string orientation = imageAnalyzer.GetImageOrientation(width, height);
            Console.WriteLine($"The image is {orientation}.");

            ///Speed camera
            ///

            Console.Write("Enter the speed limit: ");
            int speedLimit = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the car speed: ");
            int carSpeed = Convert.ToInt32(Console.ReadLine());

            var speedCamera = new SpeedCamera();
            speedCamera.CheckSpeed(speedLimit, carSpeed);


        }
    }
}