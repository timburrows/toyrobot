using System;

namespace ToyRobot.Math
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        
        /// <summary>
        /// Constructs a new Vector with default x, y and z components (0f, 0f, 0f).
        /// </summary>
        public Vector()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
        
        /// <summary>
        /// Constructs a new Vector with x, y, and z components initialized.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        
        /// <summary>
        /// Constructs a new Vector with x, y, and z components initialized.
        /// </summary>
        /// <param name="size">Initializes an equal size for x, y and z components</param>
        public Vector(double size)
        {
            X = size;
            Y = size;
            Z = size;
        }

        public static Vector operator +(Vector lhs, Vector rhs) => new Vector(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
        public static Vector operator -(Vector lhs, Vector rhs) => new Vector(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        public static Vector operator *(Vector lhs, Vector rhs) => new Vector(lhs.X * rhs.X, lhs.Y * rhs.Y, lhs.Z * rhs.Z);
        public static Vector operator /(Vector lhs, Vector rhs) => new Vector(lhs.X / rhs.X, lhs.Y / rhs.Y, lhs.Z / rhs.Z);
        public static Vector operator %(Vector lhs, Vector rhs) => new Vector(lhs.X % rhs.X, lhs.Y % rhs.Y, lhs.Z % rhs.Z);

        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException($"Cannot compare with a null {nameof(Vector)}");

            if (!(obj is Vector rhs))
                throw new InvalidCastException($"Failed to cast parameter {nameof(obj)} as {nameof(Vector)}");
            
            return rhs.X == X && rhs.Y == Y && rhs.Z == Z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
    }
}