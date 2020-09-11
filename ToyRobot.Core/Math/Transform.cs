namespace ToyRobot.Math
{
    public class Transform
    {
        /// <summary>
        /// Represents a scene components' origin in world space.
        /// </summary>
        public Vector Translation { get; set; }
        
        /// <summary>
        /// The orientation of a scene component, e.g the direction it's facing.
        /// </summary>
        /// <remarks>Using a Vector to represent Rotation here for simplicity, as opposed to a more accurate quaternion</remarks>
        public Vector Rotation { get; set; }
        
        /// <summary>
        /// The extents of a scene component from it's origin.
        /// </summary>
        public Vector Scale { get; set; }

        public Transform()
        {
            
        }
        
        public Transform(Vector position, Vector facing, Vector extents)
        {
            Translation = position;
            Rotation = facing;
            Scale = extents;
        }
    }
}