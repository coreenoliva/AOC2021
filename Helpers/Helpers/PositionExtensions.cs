namespace Helpers
{
    public class PositionExtensions
    {
        public PositionExtensions(){}

        public Position ExtractPosition(string line)
        {
            var splits = line.Split(' ').ToArray();
            
            if (splits.Count() != 2)
            {
                Console.WriteLine("Wrong amount of items in line");
                return new Position();
            }

            return new Position
            { 
                Direction = splits[0],
                Units = int.Parse(splits[1])
            };
        }

        public int CalculateDepth(List<Position> positions)
        {
            var down = positions.Where(x => x.Direction == PositionConstants.Down).Sum(y => y.Units);
            var up = positions.Where(x => x.Direction == PositionConstants.Up).Sum(y => y.Units);
            var res = down - up;
            Console.WriteLine($"Down: {down}, Up: {up}, res: {res}");
            return res;
        }

        public DepthDetail CalculateDepthDetail(List<Position> positions)
        {
            var down = positions.Where(x => x.Direction == PositionConstants.Down).Sum(y => y.Units);
            var up = positions.Where(x => x.Direction == PositionConstants.Up).Sum(y => y.Units);
            var res = down - up;
            Console.WriteLine($"Down: {down}, Up: {up}, res: {res}");
            return new DepthDetail{ Down = down, Up = up, TotalDepth = res};
        }

        public int CalculateHorizontal(List<Position> positions)
        {
            var horizontal = positions.Where(x => x.Direction == PositionConstants.Forward).Sum(y => y.Units);
            Console.WriteLine($"Horizontal: {horizontal}");
            return horizontal;
        }

        public PositionMeasurements CalculatePositionMeasurements(List<Position> positions)
        {
            var positionMeasurements = new PositionMeasurements();
            foreach (var position in positions)
            {
                if (position.Direction == PositionConstants.Down)
                {
                    positionMeasurements.Aim += position.Units;
                }
                if (position.Direction == PositionConstants.Up)
                {
                    positionMeasurements.Aim -= position.Units;
                }
                if (position.Direction == PositionConstants.Forward)
                {
                    positionMeasurements.Horizontal += position.Units;
                    positionMeasurements.Depth += positionMeasurements.Aim*position.Units;
                }
            } 

            return positionMeasurements;
        }
    }
}