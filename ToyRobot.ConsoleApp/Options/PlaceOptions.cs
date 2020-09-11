using CommandLine;
using ToyRobot.Math;

namespace ToyRobot.ConsoleApp.Options
{
    [Verb("place", HelpText = "Place the Robot on the Board. Must be the first command. Example: place 0 1 North")]
    public class PlaceOptions
    {
        [Value(0, Required = true)]
        public int PosX { get; set; }
            
        [Value(1, Required = true)]
        public int PosY { get; set; }
            
        [Value(2, Required = true)]
        public CardinalDirection Facing { get; set; }
    }
}