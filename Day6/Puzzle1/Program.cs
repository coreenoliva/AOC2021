using Helpers; 

namespace Puzzle1{
    class Program
    {
        static void Main(string[] args)
        {
            var textFileExtensions = new TextFileExtensions();
            Console.WriteLine("Reading input");

            // Read input
            var input = textFileExtensions.ReadInputLineToInts("Input.txt");



            int days = 18;
            for (int i = 0; i <= days; i++)
            {
                var substractDay = input.Select(x => x - 1);
                var res = input.Find(x => x == 0);
                
                textFileExtensions.PrintList(input);
            }
           
        }
    }
}