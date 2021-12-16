using Helpers; 

namespace Puzzle2{
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

            var measurements = positions.CalculatePositionMeasurements(extractedPositions);
                    

            Console.WriteLine($"Depth: {measurements.Depth}, Horizontal: {measurements.Horizontal}, Aim: {measurements.Aim}");
            Console.WriteLine($"total: {measurements.Horizontal * measurements.Depth} ");
        }
    }
}