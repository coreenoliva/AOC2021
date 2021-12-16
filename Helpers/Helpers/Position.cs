namespace Helpers
{
    public class Position
    {
        public string? Direction { get; set; } 
        public int Units {get; set;}
    }

    public class DepthDetail
    {
        public int Up;

        public int Down;

        public int TotalDepth;
    }

    public class PositionMeasurements
    {
        public int Horizontal{ get; set;}
        public int Depth {get; set;}
        public int Aim {get; set;}
    }

    public class PositionConstants
    {
        public static readonly string Forward = "forward";
        public static readonly string Down = "down";
        public static readonly string Up = "up";
    }
}