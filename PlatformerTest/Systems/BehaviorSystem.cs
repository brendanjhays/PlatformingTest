using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using PlatformerTest.Components;

namespace PlatformerTest.Systems
{
    class BehaviorSystem : EntityProcessingSystem
    {
        private ComponentMapper<Position> _positionMapper;
        private ComponentMapper<Physics> _physicsmapper;
        private ComponentMapper<Fighter> _fighterMapper;
        private ComponentMapper<Behavior> _behaviorMapper;

        public override void Initialize(IComponentMapperService mapperService)
        {
            _positionMapper = mapperService.GetMapper<Position>();
            _physicsmapper = mapperService.GetMapper<Physics>();
            _fighterMapper = mapperService.GetMapper<Fighter>();
        }

        public override void Process(GameTime gameTime, int entityId)
        {
            //Do this later
        }
    }
}
