namespace Puzzle1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading input");

            // Read input
            string[] input = System.IO.File.ReadAllLines("input.txt");
            int[] inputNumbers = input.Select(int.Parse).ToArray();


            // Calculate difference
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

            // Output result
            Console.WriteLine($"Number of times increased: {increaseCount}");
        }
    }
}