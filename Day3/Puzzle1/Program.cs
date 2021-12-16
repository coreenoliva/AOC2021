using Helpers;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            // textFileExtensions.PrintList(inputNumbers);

            var epsilon = new StringBuilder();
            var gamma = new StringBuilder();
            var binaryInputLength = inputNumbers[0].Count();
            var majorityCount = inputNumbers.Count()/2;

            Console.WriteLine($"binary length: {binaryInputLength}");
            Console.WriteLine($"majority count: {majorityCount}");

            for (int i = 0; i <= binaryInputLength -1 ; i++)
            {
                var res = inputNumbers.Where( x => x[i] == '1').ToList();
                // Console.WriteLine($"rescount: {res.Count}");
                if (res.Count >= majorityCount)
                {
                    gamma.Append('1');
                    epsilon.Append('0');
                }
                else{
                    gamma.Append('0');
                    epsilon.Append('1');
                }
            }

            var gammaDec = Convert.ToInt32(gamma.ToString(), 2);
            var epsilonDec = Convert.ToInt32(epsilon.ToString(), 2);

            Console.WriteLine($"gamma: {gamma}, decimal: {gammaDec}");
            Console.WriteLine($"epsilon: {epsilon}, decimal: {epsilonDec}");

            var powerConsumption  = gammaDec * epsilonDec;

            Console.WriteLine($"PowerConsumption: {powerConsumption}");





        
        }
    }
}