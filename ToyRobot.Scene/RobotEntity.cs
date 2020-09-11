using System;
using System.Linq;
using ToyRobot.Components;
using ToyRobot.Math;

namespace ToyRobot.Scene
{
    public class RobotEntity : Entity
    {
        public RobotEntity(Vector size = null) : base (size ?? new Vector(1f, 1f, 0f))
        {
        }
        
        public RobotEntity(Vector origin, CardinalDirection facing, Vector size = null)
            : base(origin, facing, size)
        {
        }

        // In a larger tree this could have performance implications, consider using state caching or alternative
        // Note: tightly couples RobotEntity to BoardEntity - may not be ideal.
        private bool TryGetBoard(out SceneComponent board)
        {
            board = GetRootComponent().ChildComponents.FirstOrDefault(x => x.GetType() == typeof(BoardEntity));
            return board != null;
        }
        
        public void Place(Vector position, CardinalDirection facing)
        {
            if (position is null)
                throw new ArgumentNullException(nameof(position));

            if (!TryGetBoard(out var board))
                throw new NullReferenceException($"{nameof(RobotEntity)} requires a {nameof(BoardEntity)} in the scene tree.");

            if (!((Entity) board).IsPositionWithinBounds(this, position)) return;
            
            SetPosition(position);
            SetOrientation(facing);
            IsSpawned = true;
        }

        public void Move()
        {
            if (!TryGetBoard(out var board))
                throw new NullReferenceException($"{nameof(RobotEntity)} requires a {nameof(BoardEntity)} in the scene tree.");

            var pos = GetPosition();
            var rotation = GetOrientation().X.ToRadians();
            var ca = System.Math.Cos(rotation);
            var sa = System.Math.Sin(rotation);
            var moveTo = new Vector(
                ca >= double.Epsilon ? 0.0 : ca,
                sa <= double.Epsilon ? 0.0 : sa, 
                0
            );

            moveTo += pos;
            
            if (IsSpawned && ((Entity) board).IsPositionWithinBounds(this, moveTo))
            {
                SetPosition(moveTo);
            }
        }

        public void RotateLeft()
        { 
            if (IsSpawned) SetRelativeOrientation(new Vector(90f, 0f, 0f));
        }
        
        public void RotateRight()
        {
            if (IsSpawned) SetRelativeOrientation(new Vector(-90f, 0f, 0f));
        }

        public void Report()
        {
            Console.WriteLine($"{(int)GetPosition().X},{(int)GetPosition().Y},{Orientation.FromVector(GetOrientation()).CardinalDirection}");
        }
    }
}