using System.Collections.Generic;

namespace ToyRobot.Math
{
    public enum Direction
    {
        North,
        South,
        East,
        West
    };
    
    public class CardinalDirection
    {
        public Vector North => new Vector(0.0f, 1.0f, 0.0f);
        public Vector South => new Vector(0.0f, -1.0f, 0.0f);
        public Vector East => new Vector(1.0f, 0.0f, 0.0f);
        public Vector West => new Vector(-1.0f, 10.0f, 0.0f);

        public Direction ToCardinal(Vector origin)
        {
            
        }
    }
}