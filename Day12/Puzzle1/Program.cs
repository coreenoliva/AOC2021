using Helpers; 

namespace Puzzle1{
    public class Program
    {
        public static void Main(string[] args)
        {
            var textFileExtensions = new TextFileExtensions();
            Console.WriteLine("Reading input");

            // Read input
            var input = textFileExtensions.ReadInputString("Input.txt");

            var maps = new List<Map>();

            // Save input 
            foreach (var line in input)
            {
                var lines = line.Split('-');
                maps.Add(new Map(lines[0], lines[1]));   
            }

            Printer.PrintMaps(maps);

            var starters = maps.Where(x => x.MapItem.Contains("start")).ToList();

            // PathFinder.FindAllPaths(maps, starters);
            Console.WriteLine("Find starters");
            // Printer.PrintMaps(starters);

            PathFinder.FindAllPaths(maps, starters);
           


        }
    }

    public static class PathFinder
    {
        public static void FindAllPaths(List<Map> maps, List<Map> starters)
        {

            int count = 0;

            foreach (var start in starters)
            {
                var path = new List<Map>();


                var pathItem = start.MapItem.OrderByDescending(x => x.Length).ToList();


                path.Add(start);

            //    var paths = FindPaths(maps, pathItem[1], path);

           var result =  FindPathsRecursion(maps, pathItem[1], path);
                
            }
            
        }

        public static List<Map> FindPaths(List<Map> maps, string starter, List<Map> found)
        {
            var nextItems = FindNextMapItem(maps, starter);
            foreach (var foundPath in found)
            {
                if (foundPath.MapItem.Select(x => x.Contains("end")).Count() > 1)
                {
                    Console.WriteLine("here");
                    // continue
                    var lastPosition = GetLastPosition(foundPath.MapItem);
                    var next = FindNextMapItem(maps, lastPosition);
                    found.AddRange(next);
                }
            }
            return found;

        }
        
        public static List<Map> FindPathsRecursion(List<Map> maps, string starter, List<Map> found)
        {
            var foundMaps = new List<Map>();

            foundMaps.AddRange(found);

            foreach (var item in found){
                if (item.MapItem.Contains("end"))
                {
                    continue;
                }
                else
                {               
                    
                    var lastPosition = GetLastPosition(item.MapItem);

                    foundMaps.AddRange(FindPathsRecursion(maps, lastPosition, foundMaps));}

                    }

            return foundMaps;
        }


        public static string GetLastPosition(List<string> positions){
            return positions[positions.Count()-1]; 
        }

        public static List<Map> FindNextMapItem(List<Map> maps, string lastItem)
        {
            var res = maps.Where(x => x.MapItem.Contains(lastItem)).ToList();
            return res;
        }

    }

    // public struct Map
    // {
    //     public Map(string positionA, string positionB)
    //     {
    //         PositionA =  positionA;
    //         PositionB = positionB;
    //     }
    //     public string PositionA {get; set;}
    //     public string PositionB {get; set;}
    // }

    public class Map
    {
        public Map(string positionA, string positionB)
        {
            MapItem = new List<string>();
            MapItem.Add(positionA);
            MapItem.Add(positionB);
        }

        public List<string> MapItem{ get;set; }
    }


    public static class Printer
    {

        // public static void PrintMaps(List<Map> maps)
        // {
        //     foreach (var map in maps)
        //     {
        //         Console.WriteLine($"PositionA: {map.PositionA}, PositionB: {map.PositionB}");
        //     }
        // }

        public static void PrintMaps(List<Map> maps)
        {
            foreach (var map in maps)
            {
                Console.WriteLine("-");
                foreach (var mapItem in map.MapItem)
                {
                    Console.WriteLine(mapItem);
                }
            }
        }

    }
}