namespace Puzzle2
{
    class Program
    {
        static void Main(string[] args)
        {
            var textFileExtensions = new TextFileExtensions();
            var calculationExtensions = new CalculationExtensions();

            // Read input
            var inputNumbers = textFileExtensions.ReadInputInt("input.txt");

            var calculatedMeasurementWindows = calculationExtensions.CalculateThreeMeasurementSlidingWindow(inputNumbers);
            var result = calculationExtensions.CalculateIncrease(calculatedMeasurementWindows);

            Console.WriteLine($"Output: {result}");
        
        }
    }
}