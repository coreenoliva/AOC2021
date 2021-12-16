using Helpers;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzle2
{
    class Program
    {
        static void Main(string[] args)
        {
            var textFileExtensions = new TextFileExtensions();
            var calculationExtensions = new CalculationExtensions();

            // Read input
            var inputNumbers = textFileExtensions.ReadInputString("input.txt");

            var binaryInputLength = inputNumbers[0].Count();


            Console.WriteLine($"binary length: {binaryInputLength}");


            var oxygenGenerator = new List<string>();
            var scrubberRating = new List<string>();

            foreach (var input in inputNumbers){
                oxygenGenerator.Add(input);
                scrubberRating.Add(input);
            }

            for (int i = 0; i <= binaryInputLength -1 ; i++)
            {

                if (oxygenGenerator.Count > 1)
                {

          
                    var oxygenCount1 = oxygenGenerator.Where( x => x[i] == '1').ToList();
                    var oxygenCount0 = oxygenGenerator.Where( x => x[i] == '0').ToList();


                    // Console.WriteLine($"oxygenCount1: {oxygenCount1.Count}, oxygenCount0: {oxygenCount0.Count}");
                    if (oxygenCount0.Count == oxygenCount1.Count)
                    {
                        // Keep 1
                        oxygenCount0.ForEach(x => oxygenGenerator.RemoveAll( y => y == x));  
                    }
                    else if (oxygenCount1.Count >= oxygenCount0.Count)
                    {
                        oxygenCount0.ForEach(x => oxygenGenerator.RemoveAll( y => y == x));  
                    }
                    else
                    {
                        // Console.WriteLine("Removing 1");
                        // Remove 1's 
                        oxygenCount1.ForEach(x => oxygenGenerator.RemoveAll( y => y == x));
                    }

                }



                
                if (scrubberRating.Count > 1)
                {
                    var scrubberCount1 = scrubberRating.Where( x => x[i] == '1').ToList();
                    var scrubberCount0 = scrubberRating.Where( x => x[i] == '0').ToList();

                    // Console.WriteLine($"scrubberCount1: {scrubberCount1.Count}, scrubberCount0: {scrubberCount0.Count}");

                    if (scrubberCount1.Count == scrubberCount0.Count)
                    {
                        // remove 1
                        scrubberCount1.ForEach(x => scrubberRating.RemoveAll( y => y == x));  

                    }
                    else if (scrubberCount1.Count > scrubberCount0.Count)
                    {
                        // Remove 1's
                        scrubberCount1.ForEach(x => scrubberRating.RemoveAll( y => y == x));  
                    }
                    else 
                    {
                        // Console.WriteLine("Removing 1");
                        // Remove 0's 
                        scrubberCount0.ForEach(x => scrubberRating.RemoveAll( y => y == x));
                    }
                }


                // Console.WriteLine("Remaining oxygenGenerator list:");
                // textFileExtensions.PrintList(oxygenGenerator);

                // Console.WriteLine("Remaining scrubber list:");
                // textFileExtensions.PrintList(scrubberRating);
            }


            var oxygenGeneratorValue = Convert.ToInt32(oxygenGenerator[0], 2);
             var scrubberCountValue = Convert.ToInt32(scrubberRating[0], 2);

            var lifeSupportRating = oxygenGeneratorValue * scrubberCountValue;

            Console.WriteLine($"oxygenGEnerator: {oxygenGeneratorValue}, scrubberCountValue: {scrubberCountValue}, lifeSupportRating: {lifeSupportRating}");

            // var gammaDec = Convert.ToInt32(gamma.ToString(), 2);
            // var epsilonDec = Convert.ToInt32(epsilon.ToString(), 2);

            // Console.WriteLine($"gamma: {gamma}, decimal: {gammaDec}");
            // Console.WriteLine($"epsilon: {epsilon}, decimal: {epsilonDec}");

            // var powerConsumption  = gammaDec * epsilonDec;

            // Console.WriteLine($"PowerConsumption: {powerConsumption}");





        
        }
    }
}