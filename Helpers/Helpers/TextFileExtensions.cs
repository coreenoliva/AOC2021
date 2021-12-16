using System.Text;

namespace Helpers
{
    public class TextFileExtensions
    {
        public TextFileExtensions() {}

        public List<int> ReadInputInt(string fileName)
        {
            var stringInput = this.ReadInputString(fileName);
            return stringInput.Select(int.Parse).ToList();
        }

        public List<string> ReadInputString(string fileName)
        {
            return System.IO.File.ReadAllLines(fileName).ToList();
        }

        public List<int> ReadInputLineToInts(string filename)
        {
            var line = System.IO.File.ReadAllText(filename);
            var splitLine = line.Split(',');
            return splitLine.Select(int.Parse).ToList();
        }

        public void PrintList(List<int> input)
        {
            Console.WriteLine("Printing List");
            foreach (var thing in input)
            {
                Console.WriteLine($"{thing}");
            }
        }

        public void PrintList(List<string> input)
        {
            Console.WriteLine("Printing List");
            foreach (var thing in input)
            {
                Console.WriteLine($"{thing}");
            }
        }

        public string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }

    public static class StringExtensions
    
        {
        public static bool ContainsAny(this string haystack, params string[] needles)
            {
                Console.WriteLine($"haystack:{haystack}");
                foreach (string needle in needles)
                {
                    Console.WriteLine($"needle: {needle}");
                    if (haystack.Contains(needle))
                        return true;
                }

                return false;
            }
        

        public static bool ContainsAllOfTheseCharacters(this string haystack, string theseCharacters)
        {
                // Console.WriteLine($"haystack: {haystack}");
                foreach(var character in theseCharacters)
                {
                    // Console.WriteLine($"character: {character}");
                    if (haystack.Contains(character))
                    {
                        continue;
                    }
                    else{
                        return false;
                    }
                }

                // if we get here means all characters exist in the haystazck
                return true;
        }
        public static string GiveMeCharactersThatDontMatch(this string haystack, string theseCharacters)
        {
            var matchless = new StringBuilder();

            foreach(var character in theseCharacters)
            {
                if (!haystack.Contains(character))
                {
                    matchless.Append(character);
                }
                else{
                    continue;
                }
            }

            return matchless.ToString();

        }
        // public static char FindTheCharacterThatIsntInCommon(this string haystack, List<string> theseStrings)
        // {
        //     foreach (var word in theseStrings)
        //     {
        //         var matchless = word.GiveMeCharactersThatDontMatch(word);


        //     }
        // }
    }
}