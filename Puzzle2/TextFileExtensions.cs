namespace Puzzle2
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

    }
}