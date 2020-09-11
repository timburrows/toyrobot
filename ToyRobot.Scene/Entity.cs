using ToyRobot.Components;
using ToyRobot.Math;

namespace ToyRobot.Scene
{
    public abstract class Entity : SceneComponent, IEntity
    {
        /// <summary>
        /// Constructs a new Board and places it in the world at x: 0, y: 0, z: 0, with a default configuration.
        /// </summary>
        /// <param name="size"></param>
        protected Entity(Vector size = null)
        {
            SetPosition(0f, 0f, 0f);
            SetOrientation(CardinalDirection.North);
            SetScale(size ?? new Vector());
        }
        
        /// <summary>
        /// Constructs a new Board and places it in the world at the specified origin and configuration.
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="facing"></param>
        /// <param name="size"></param>
        protected Entity(Vector origin, CardinalDirection facing, Vector size = null)
        {
            SetPosition(origin);
            SetOrientation(facing);
            SetScale(size ?? new Vector());
        }
        
        public bool IsPositionWithinBounds(SceneComponent component, Vector newPosition)
        {
            return
                System.Math.Abs(newPosition.X) + component.GetScale().X <=
                System.Math.Abs(GetPosition().X) + GetScale().X
                &&
                System.Math.Abs(newPosition.Y) + component.GetScale().Y <=
                System.Math.Abs(GetPosition().Y) + GetScale().Y
                &&
                System.Math.Abs(newPosition.Z) + component.GetScale().Z <=
                System.Math.Abs(GetPosition().Z) + GetScale().Z;
        }

        public bool IsComponentWithinBounds(SceneComponent component)
        {
            return
                component.GetPosition().X + component.GetScale().X <= GetPosition().X + GetScale().X
                &&
                component.GetPosition().Y + component.GetScale().Y <= GetPosition().Y + GetScale().Y
                &&
                component.GetPosition().Z + component.GetScale().Z <= GetPosition().Z + GetScale().Z;
        }

        public bool IsSpawned { get; set; }
    }
}