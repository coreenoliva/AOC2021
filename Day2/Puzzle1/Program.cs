using Helpers; 

namespace Puzzle1
{
    class Program
    {
        static void Main(string[] args)
        {

            var positions = new PositionExtensions();

            Console.WriteLine("Reading input");

            // Read input
            string[] input = System.IO.File.ReadAllLines("input.txt");
            
            var extractedPositions = new List<Position>();

            foreach (var line in input)
            {
                var position = positions.ExtractPosition(line);
                extractedPositions.Add(position);
                Console.WriteLine($"Direction {position.Direction}, Units: {position.Units}");
            }
            
            // calculate depth 
            var depth = positions.CalculateDepth(extractedPositions);

            //calculate horizontal position
            var horizontal = positions.CalculateHorizontal(extractedPositions);

            var total = horizontal * depth;

            Console.WriteLine($"Total: {total}");


        }
    }
}