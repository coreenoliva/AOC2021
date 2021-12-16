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
            var inputFile = textFileExtensions.ReadInputString("input.txt");
            var drawLine = inputFile[0];

            var boards = new List<List<string>>();

            for(int i = 2; i <= inputFile.Count(); i+= 6)
            {
                Console.WriteLine(inputFile[i]);

                var board = new List<string>();

                board.Add(inputFile[i]);
                board.Add(inputFile[i+1]);
                board.Add(inputFile[i+2]);
                board.Add(inputFile[i+3]);
                board.Add(inputFile[i+4]);

                boards.Add(board);
                textFileExtensions.PrintList(board);
            }

            // go through each bingo draw
            foreach(var draw in drawLine)
            {
                // check if number exists in any of the boards
                foreach (var board in boards)
                {
                    // check board for number

                    

                    // check for win
                }

            }

        }

 
    }
}