using System;

namespace ToyRobot.Components
{
    public class RootComponent : SceneComponent
    {
        public override SceneComponent ParentComponent => null;

        public override void AttachComponent(SceneComponent parentComponent)
        { 
            throw new ApplicationException($"{nameof(RootComponent)} must be the base of all components");
        }
    }
}