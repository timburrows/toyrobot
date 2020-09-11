using ToyRobot.Components;
using ToyRobot.Math;

namespace ToyRobot.Scene
{
    public interface IEntity
    {
        /// <summary>
        /// Validates if a Vector is within the bounds of this Entity.
        /// </summary>
        /// <param name="component"></param>
        /// <param name="position"></param>
        /// <returns>True if Vector is within bounds.</returns>
        bool IsPositionWithinBounds(SceneComponent component, Vector position);

        /// <summary>
        /// Validates if a SceneComponent is within the bounds of this Entity.
        /// </summary>
        /// <param name="component"></param>
        /// <returns>True if the SceneComponent is within bound.</returns>
        public bool IsComponentWithinBounds(SceneComponent component);

        public bool IsSpawned { get; set; }
    }
}