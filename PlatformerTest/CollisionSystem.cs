using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace PlatformerTest
{
    class CollisionSystem
    {
        private List<CollisionBox> _dynamicColliders;
        private List<CollisionBox> _staticColliders;

        private Vector2 _gravity;

        public CollisionSystem(Vector2 gravity)
        {
            _gravity = gravity;
        }

        public void Update()
        {
            UpdateDynamicColliders();
        }

        public void UpdateDynamicColliders()
        {
            foreach (CollisionBox c in _dynamicColliders)
            {
                c.Position = Vector2.Add(c.Position, _gravity);
            }
        }

        public void CheckForCollision()
        {
            foreach (CollisionBox c in _dynamicColliders)
            {
                Vector2 xBounds = new Vector2(c.Position.X, c.Position.X + c.Size.X);
                Vector2 yBounds = new Vector2(c.Position.Y, c.Position.Y - c.Size.Y);
            }
        }
    }
}
