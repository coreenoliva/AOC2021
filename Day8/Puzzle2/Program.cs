using Helpers;
using System.Text;
using static Helpers.StringExtensions;


namespace Puzzle2
{
    class Program
    {
        static void Main(string[] args)
        {

                        
            var textFileExtensions = new TextFileExtensions();
            var calculationExtensions = new CalculationExtensions();

            // var nine = textFileExtensions.SortString("cefabd");
            // var eight = textFileExtensions.SortString("acedgfb");
            // var seven = textFileExtensions.SortString("dab");
            // var six =  textFileExtensions.SortString("gcdfa");
            // var five = textFileExtensions.SortString("cdfbe");
            // var four = textFileExtensions.SortString("eafb");
            // var three = textFileExtensions.SortString("fbcad");
            // var two = textFileExtensions.SortString("gcdfa");
            // var one = textFileExtensions.SortString("ab");


            // Read input
            var inputNumbers = textFileExtensions.ReadInputString("input.txt");
            // var splitOutput = inputNumbers.Select(x => x).Where(x => x.Split('|'));

            var solvedLineOutputData = 0;
            
            foreach( var line in inputNumbers )
            {
                    

                    var nine = "";
                    var eight = "";
                    var seven = "";
                    var six =  "";
                    var five = "";
                    var four = "";
                    var three = "";
                    var two = "";
                    var one = "";
                    var zero = "";

                    var split = line.Split('|').ToList();
                    // textFileExtensions.PrintList(split);       
                    var samples = split[0].Split(' ');

                    var orderedList = new List<string>();
                    // need to order samples

                    orderedList.AddRange(samples.Where(x => x.Count() == 2 || x.Count() == 4 || x.Count() == 3 || x.Count() == 7));
                    orderedList.AddRange(samples.Where(x => x.Count() == 5));
                    orderedList.AddRange(samples.Where(x => x.Count() == 6));

                    var numberCounter = 0;
                    var solved = new List<string>();
                    var solvedWiring = new Dictionary<string, char>();

                    while(numberCounter < 10)
                    {
                        // Console.WriteLine($"NumberCounter: {numberCounter}");
                        // Console.WriteLine($"numberSample: {numberSample}, numberLength: {numberLength}");
                        foreach (var numberSampleNotOrdered in orderedList)
                        {
                            var numberSample = textFileExtensions.SortString(numberSampleNotOrdered);
                            var numberLength = numberSample.Count();

                        switch (numberLength)
                        {
                            case 2: 
                                if (one == "")
                                {
                                    one = numberSample;
                                    solvedWiring.Add(textFileExtensions.SortString(one), '1');
                                    Console.WriteLine($"1: {numberSample}");    
                                    numberCounter++;
                                    solved.Add(textFileExtensions.SortString(numberSample));


                                }
                                    break;

                            case 3:
                                 if (seven == "")
                                 {
                                    seven = numberSample;
                                    Console.WriteLine($"7: {numberSample}");
                                    solvedWiring.Add(textFileExtensions.SortString(seven), '7');
                                    numberCounter++;
                                    solved.Add(textFileExtensions.SortString(numberSample));

                                 }
                                    break;

                            case 4:
                                if (four == "")
                                {
                                    four = numberSample;
                                    Console.WriteLine($"4: {numberSample}");
                                    solvedWiring.Add(textFileExtensions.SortString(four),'4');
                                    numberCounter++;
                                    solved.Add(textFileExtensions.SortString(numberSample));

                                }
                                break;

                            case 7: 
                                if (eight == "")
                                {
                                    eight= numberSample;
                                    Console.WriteLine($"8: {numberSample}");
                                    solvedWiring.Add(textFileExtensions.SortString(eight), '8');
                                    numberCounter++;
                                    solved.Add(textFileExtensions.SortString(numberSample));

                                }

                                break;

                            case 5:
                                // 5 or 3
                                if (!solved.Contains(numberSample))
                                {
                                    // Console.WriteLine($"here: {numberSample}");
                                    if (three == "" )
                                    {
                                        var result = numberSample.ContainsAllOfTheseCharacters(one);   
                                        if (result)
                                        {
                                            three = numberSample;
                                            Console.WriteLine($"3: {numberSample}");
                                            solvedWiring.Add(textFileExtensions.SortString(three),'3');
                                            numberCounter++;
                                            solved.Add(textFileExtensions.SortString(numberSample));

                                        }
                                       
                                    }
                                     else{
                                            var matchlessWithThree = three.GiveMeCharactersThatDontMatch(four);
                                            var contains = numberSample.ContainsAllOfTheseCharacters(matchlessWithThree);
                                            if(contains)
                                            {
                                                five = numberSample;
                                                Console.WriteLine($"5: {numberSample}");
                                                solvedWiring.Add(textFileExtensions.SortString(five), '5');
                                                solved.Add(textFileExtensions.SortString(numberSample));
                                            }
                                            else
                                            {
                                                two = numberSample;
                                                Console.WriteLine($"2: {numberSample}");
                                                solvedWiring.Add(textFileExtensions.SortString(two), '2');
                                                solved.Add(textFileExtensions.SortString(numberSample));

                                            }

                                            numberCounter++;
                                            solved.Add(textFileExtensions.SortString(numberSample));

                                        }
                                }
                                break;

                            case 6: 
                                // Console.WriteLine($"here: {numberSample}");

                                if (!solved.Contains(numberSample))
                                {
                                    // textFileExtensions.PrintList(solved);
                                    if (six == "" )
                                    {
                                        var result = numberSample.ContainsAllOfTheseCharacters(one); 
                                        if (result)
                                        {
                                            // Console.WriteLine("probably 9 or 0");

                                        }
                                        else 
                                        {
                                                                                        six = numberSample;
                                            Console.WriteLine($"6: {numberSample}");
                                            solvedWiring.Add(textFileExtensions.SortString(six),'6');
                                            numberCounter++;
                                            solved.Add(textFileExtensions.SortString(numberSample));

                                        }
                                    
                                    
                                    } 
                                    else if (nine == "")
                                    {
                                        var result = numberSample.ContainsAllOfTheseCharacters(four);
                                        if(result)
                                        {
                                            nine = numberSample;
                                            Console.WriteLine($"9: {numberSample}");
                                            solvedWiring.Add(textFileExtensions.SortString(nine),'9');
                                            numberCounter++;
                                            solved.Add(textFileExtensions.SortString(numberSample));
                                        }
                                    
                                    }
                                    else if (six != "" && nine != "") 
                                    {
                                        zero = numberSample;
                                        Console.WriteLine($"0: {numberSample}");
                                        solvedWiring.Add(textFileExtensions.SortString(zero),'0');
                                        numberCounter++;
                                        solved.Add(textFileExtensions.SortString(numberSample));
                                    }

                                    
                                   
                                }
                                
                                break;


                            default:

                                break;
                            
                        }

                        // Console.WriteLine($"NumberCounter: {numberCounter}");

                        }
                    }
                    Console.WriteLine($"resolved numbers - 0: {zero}, 1: {one}, 2: {two}, 3: {three}, 4: {four}, 5: {five}, 6: {six}, 7: {seven}, 8: {eight}, 9: {nine}");
                
                var decodedOutputNumber = new StringBuilder(); 

                // Decoding output
                var outputDatas = split[1].Split(' ');

                // textFileExtensions.PrintList(outputDatas.ToList());

                foreach (var outputData in outputDatas)
                {
                    if (!String.IsNullOrEmpty(outputData))
                    {
                        var sortedOutputData = textFileExtensions.SortString(outputData);
                        decodedOutputNumber.Append(solvedWiring[sortedOutputData]);
                    }
                }

                solvedLineOutputData += int.Parse(decodedOutputNumber.ToString());
                Console.WriteLine($"Decoded outputnumber: {decodedOutputNumber}, Sum of outputdata: {solvedLineOutputData}");
                 

                }

                
            }
        
    }
}