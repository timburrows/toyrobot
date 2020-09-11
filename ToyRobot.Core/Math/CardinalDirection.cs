using System.Collections.Generic;

namespace ToyRobot.Math
{
    public enum CardinalDirection
    {
        North,
        South,
        East,
        West
    };

    public class Orientation
    {
        public CardinalDirection CardinalDirection { get; set; }
        public Vector Direction { get; set; }
        
        public static Orientation FromCardinal(CardinalDirection cardinalDirection)
        {
            var cardinalToVec = new Dictionary<CardinalDirection, Vector>
            {
                {CardinalDirection.North, new Vector(90, 0, 0)},
                {CardinalDirection.South, new Vector(-90, 0, 0)},
                {CardinalDirection.East, new Vector(0, 0, 0)},
                {CardinalDirection.West, new Vector(180, 0, 0)}
            };

            return new Orientation()
            {
                Direction = cardinalToVec[cardinalDirection],
                CardinalDirection = cardinalDirection
            };
        }

        public static Orientation FromVector(Vector rotationDegrees)
        {
            var vecToCardinal = new Dictionary<Vector, CardinalDirection>
            {
                {new Vector(90, 0, 0), CardinalDirection.North},
                {new Vector(-90, 0, 0), CardinalDirection.South},
                {new Vector(0, 0, 0), CardinalDirection.East},
                {new Vector(180, 0, 0), CardinalDirection.West}
            };

            return new Orientation()
            {
                CardinalDirection = vecToCardinal[rotationDegrees],
                Direction = rotationDegrees
            };
        }
    }
}