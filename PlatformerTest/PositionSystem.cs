using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Entities;
using Microsoft.Xna.Framework;

namespace PlatformerTest
{
    class PositionSystem : EntityUpdateSystem
    {
        private ComponentMapper<Position> _positionMapper;
        private ComponentMapper<Physics> _physicsMapper;
        public PositionSystem() : base(Aspect.All(typeof(Position), typeof(Physics)))
        {
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _positionMapper = mapperService.GetMapper<Position>();
            _physicsMapper = mapperService.GetMapper<Physics>();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var e in ActiveEntities)
            {
                //Updates position vector based on velocity vector
                Position position = _positionMapper.Get(e);
                Physics physics = _physicsMapper.Get(e);
                position.position = Vector2.Add(position.position, physics.velocity);
                _positionMapper.Put(e, position);
            }
        }
    }
}
