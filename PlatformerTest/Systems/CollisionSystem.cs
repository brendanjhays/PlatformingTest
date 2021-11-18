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

        public void RegisterCollider(CollisionBox collider)
        {
            if (collider.Type == ColliderType.Static) _staticColliders.Add(collider);
            else _dynamicColliders.Add(collider);
        }

        public void RemoveCollider(CollisionBox collider)
        {
            if (collider.Type == ColliderType.Static) _staticColliders.Remove(collider);
            else _dynamicColliders.Remove(collider);
        }

        public void Update()
        {
            UpdateDynamicColliders();
        }

        public void ResolveCollisions(CollisionBox colliderDynamic)
        {
            foreach (CollisionBox colliderStatic in _staticColliders)
            {
                bool[] collisionInformation = CheckAabbAabb(colliderDynamic.Bounding, colliderStatic.Bounding);
                if (!collisionInformation[0])
                {
                    float overlap;
                    if (collisionInformation[1])
                    {
                        if (colliderDynamic.Bounding.Min.X > colliderStatic.Bounding.Min.X)
                        {
                            overlap = colliderStatic.Bounding.Max.X - colliderDynamic.Bounding.Min.X;
                        }
                        else if 
                    }
                    else
                    {

                    }
                }
            }
        }

        public void UpdateDynamicColliders()
        {
            foreach (CollisionBox c in _dynamicColliders)
            {
                c.Position = Vector2.Add(c.Position, _gravity);
            }
        }

        public bool[] CheckAabbAabb(BoundingBox a, BoundingBox b)
        {
            bool[] result = new bool[2];
            result = [true, false];
            //True denotes no collision, false means collision is currently occurring
            if (a.Min.X < b.Max.X || a.Max.X < b.Min.X) { }
            else
            {
                result = [false, true];
                return result;
            }
            if (a.Min.Y < b.Max.Y || a.Max.Y < b.Min.Y) { }
            else
            {
                result = [false, false];
                return result;
            }
            return result;
        }
    }
}
