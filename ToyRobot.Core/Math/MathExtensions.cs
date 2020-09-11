namespace ToyRobot.Math
{
    public static class MathExtensions
    {
        public static double ToRadians(this double degrees)
        {
            var rad = degrees * (System.Math.PI / 180.0);
            return rad;
        }
    }
}