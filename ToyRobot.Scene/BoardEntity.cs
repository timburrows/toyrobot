using ToyRobot.Math;

namespace ToyRobot.Scene
{
    public class BoardEntity : Entity
    {
        public BoardEntity(Vector size = null) : base (size ?? new Vector(5f, 5f, 0f))
        {
            IsSpawned = true;
        }
    }
}