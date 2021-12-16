using Helpers;


namespace Puzzle1
{
    class Program
    {
        static void Main(string[] args)
        {
            var textFileExtensions = new TextFileExtensions();
            var calculationExtensions = new CalculationExtensions();

            // Read input
            var inputNumbers = textFileExtensions.ReadInputString("input.txt");
            // var splitOutput = inputNumbers.Select(x => x).Where(x => x.Split('|'));

            var outputData = new List<string>();
            foreach( var line in inputNumbers )
                {
                    var split = line.Split('|').ToList();
                    // textFileExtensions.PrintList(split);       

                    outputData.Add(split[1]);     
                }


            // Console.WriteLine(splitOutput);

            // textFileExtensions.PrintList(splitOutput);

            // var outputData = splitOutput.Where(x => !x.Contains("|"));
            // textFileExtensions.PrintList(outputData.ToList());

            int counter = 0;

            // split each line into list 
            foreach (var line in outputData)
            {
                var splitLine = line.Split(' ');
                // Console.WriteLine(splitLine);
                // textFileExtensions.PrintList(splitLine.ToList());

                counter += splitLine.Where(x => x.Count() == 2 || x.Count() == 4 || x.Count() == 3 || x.Count() == 7).Count();
                // Console.WriteLine(counter);
            }

            Console.WriteLine($"total number of unique: {counter}");

        
        }
    }
}