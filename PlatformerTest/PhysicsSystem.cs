using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace PlatformerTest
{
    class PhysicsSystem : EntityUpdateSystem
    {
        private ComponentMapper<Physics> _physicsMapper;
        public PhysicsSystem() : base(Aspect.One(typeof(Physics)))
        {

        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _physicsMapper = mapperService.GetMapper<Physics>();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var e in ActiveEntities)
            {
                //Add the acceleration vector to the velocity vector for all entities with a physics component
                Physics physics = _physicsMapper.Get(e);
                physics.velocity = Vector2.Add(physics.velocity, physics.acceleration);
            }
        }
    }
}
