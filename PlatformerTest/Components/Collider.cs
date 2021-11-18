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
        public BoundingBox Bounding;
    }

    public struct BoundingBox
    {
        //Min represents lowest x,y coordinates, max represents highest x,y coordinates
        public BoundingBox(Vector2 min, Vector2 max)
        {
            Min = min;
            Max = max;

            Width = max.X - min.X;
            Height = max.Y - min.Y;
        }

        public Vector2 Min;
        public Vector2 Max;

        public float Width;
        public float Height;
    }
}
