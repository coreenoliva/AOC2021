namespace Puzzle2
{
    public class CalculationExtensions
    {
        public CalculationExtensions() {}

        public int CalculateIncrease(List<int> inputNumbers)
        {
            int increaseCount = 0; 

            var previous = inputNumbers[0];

            inputNumbers.ToList().RemoveAt(0);

            foreach (var dataItem in inputNumbers)
            {
                if (dataItem > previous)
                {
                    increaseCount++;
                }

                previous = dataItem;
            }

            return increaseCount;
        }

        public List<int> CalculateThreeMeasurementSlidingWindow(List<int> inputNumbers)
        {
             var calculatedMeasurementWindows = new List<int>();
            // Calculate measurement windows
            Console.WriteLine("Calculating Measurements windows");
            for (int i=0; i <= inputNumbers.Count-3; i++)
            {
                calculatedMeasurementWindows.Add(inputNumbers[i] + inputNumbers[i+1] + inputNumbers[i+2]);

                Console.WriteLine($"calculatedMeasurementWindows: {calculatedMeasurementWindows[i]}");
            }

            return calculatedMeasurementWindows;
        }
    }
}