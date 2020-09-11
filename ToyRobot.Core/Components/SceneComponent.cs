using System;
using System.Collections.Generic;
using ToyRobot.Math;

namespace ToyRobot.Components
{
    public class SceneComponent : ISceneComponent
    {
        private Transform Transform { get; } = new Transform();
        public virtual SceneComponent ParentComponent { get; private set; }
        public IList<SceneComponent> ChildComponents { get; } = new List<SceneComponent>();
        
        protected SceneComponent()
        {
            
        }

        public virtual void AttachComponent(SceneComponent parentComponent)
        {
            parentComponent.ChildComponents.Add(this);
            ParentComponent = parentComponent;
        }

        public SceneComponent GetRootComponent(SceneComponent component = null)
        {
            component = component == null ? ParentComponent : component.ParentComponent;
            if (component.ParentComponent != null)
                GetRootComponent(component);

            return component;
        }
        
        // Translation
        public void SetPosition(double x, double y, double z) => Transform.Translation = new Vector(x, y, z);
        public void SetPosition(Vector newPosition) => Transform.Translation = newPosition;
        public void AddRelativePosition(double deltaX, double deltaY, double deltaZ) => 
            Transform.Translation += new Vector(deltaX, deltaY, deltaZ);
        public void AddRelativePosition(Vector deltaPosition) => Transform.Translation += deltaPosition;
        public Vector GetPosition() => Transform.Translation;

        // Rotation
        public void SetOrientation(CardinalDirection direction) => 
            Transform.Rotation = Orientation.FromCardinal(direction).Direction;
        public void SetRelativeOrientation(Vector deltaRotation)
        {
            Transform.Rotation += deltaRotation % new Vector(180, 180, 180);
            
            if (Transform.Rotation.X <= -180)
                Transform.Rotation.X += 180;
            if (Transform.Rotation.X > 180)
                Transform.Rotation.X -= 180;

            if (Transform.Rotation.Y <= -180)
                Transform.Rotation.Y += 180;
            if (Transform.Rotation.Y > 180)
                Transform.Rotation.Y -= 180;
            
            if (Transform.Rotation.Z <= -180)
                Transform.Rotation.Z += 180;
            if (Transform.Rotation.Z > 180)
                Transform.Rotation.Z -= 180;
        }

        public Vector GetOrientation() => Transform.Rotation;
        
        // Scale
        public void SetScale(Vector extents) => Transform.Scale = extents;
        public Vector GetScale() => Transform.Scale;
    }
    
    public static class SceneComponentExtensions
    {
        public static T Attach<T>(this T parentComponent, SceneComponent component)
            where T : SceneComponent
        {
            component.AttachComponent(parentComponent);
            return parentComponent;
        }
        
        // public static T Attach<T>(this T parentComponent, Func<T> expression)
        //     where T : SceneComponent
        // {
        //     var component = expression.Invoke();
        //     return component;
        // }
        
        public static T AttachTo<T>(this SceneComponent component, T parentComponent)
            where T : SceneComponent
        {
            component.AttachComponent(parentComponent);
            return parentComponent;
        }
        
        // public static T AttachTo<T>(this T component, Func<T> expression)
        //     where T : SceneComponent
        // {
        //     var parentComponent = expression.Invoke();
        //     return parentComponent;
        // }
    }
}