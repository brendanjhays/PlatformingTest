using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace PlatformerTest
{
    public enum ColliderType
    {
        Static, Dynamic
    }

    public class CollisionBox
    {
        public ColliderType Type = ColliderType.Static;
        public Vector2 Position;
        public Vector2 Size;
        public Behavior ColliderBehavior;
    }

    public class BoundingBox
    {

    }
}
