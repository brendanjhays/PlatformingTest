using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PlatformerTest
{
    class EntityFactory
    {
        private readonly World _world;
        private readonly ContentManager _contentManager;
        
        public EntityFactory(World world, ContentManager content)
        {
            _world = world;
            _contentManager = content;
        }

        public Entity CreatePlayer(Vector2 initialPosition)
        {
            var player = _world.CreateEntity();
            player.Attach(new Position(initialPosition));
            var p = new Physics
            {
                xAcceleration = 1.2f,
                xAirAcceleration = 1.0f,
                velocityMod = 0.85f
            };
            player.Attach(p);
            player.Attach(new Render(_contentManager.Load<Texture2D>("Lemming")));
            player.Attach(new Player());
            return player;
        }

        public Entity CreateTile(Vector2 position, Vector2 size)
        {
            var entity = _world.CreateEntity();
            entity.Attach(new CollisionBox
            {
                Type = ColliderType.Static,
                Position = position,
                Size = size
            });
            return entity;
        }

        public Entity CreateMovingTile(Vector2 position, Vector2 size, Behavior behavior)
        {
            var entity = _world.CreateEntity();
            entity.Attach(new CollisionBox
            {
                Type = ColliderType.Dynamic,
                Position = position,
                Size = size,
                ColliderBehavior = behavior
            });
            return entity;
        }

        public Behavior CreateBehavior(World world, List<Condition> conditions, List<Condition> orderedConditions, bool loop, int startIndex)
        {
            Behavior behavior = new Behavior(loop, world);
            foreach (Condition c in conditions)
            {
                behavior.RegisterCondition(c);
            }
            foreach (Condition c in orderedConditions)
            {
                behavior.RegisterCondition(c);
            }
            behavior.OrderedIndex = startIndex;
            return behavior;
        }

        public Behavior CreateBehavior(World world, List<Condition> conditions, bool loop, int startIndex)
        {
            Behavior behavior = new Behavior(loop, world);
            foreach (Condition c in conditions)
            {
                behavior.RegisterCondition(c);
            }
            behavior.OrderedIndex = startIndex;
            return behavior;
        }

        public Behavior CreateBehavior(World world, List<Condition> conditons, bool loop)
        {
            Behavior behavior = new Behavior(loop, world);
            foreach (Condition c in conditons)
            {
                behavior.RegisterCondition(c);
            }
            return behavior;
        }

        public Behavior CreateBehavior(World world, bool loop)
        {
            Behavior behavior = new Behavior(loop, world);
            return behavior;
        }
    }
}
