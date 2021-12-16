using Helpers; 

namespace Puzzle1{
    class Program
    {
        static void Main(string[] args)
        {
            var textFileExtensions = new TextFileExtensions();
            Console.WriteLine("Reading input");

            // Read input
            var input = textFileExtensions.ReadInputLineToInts("Input.txt");
           textFileExtensions.PrintList(input);

            var crabPosition = new List<int>();
            var crabFuelIntake = new List<int>();

            var test = input.ToArray() -1;

           
        }
    }
}