using ToyRobot.Math;

namespace ToyRobot.Components
{
    public interface ISceneComponent
    {
        void SetPosition(double x, double y, double z);
        void SetPosition(Vector newPosition);
        void AddRelativePosition(double deltaX, double deltaY, double deltaZ);
        void AddRelativePosition(Vector deltaPosition);
        void SetOrientation(CardinalDirection direction);
        void SetScale(Vector extents);
    }
}