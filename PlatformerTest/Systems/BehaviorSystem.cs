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

        public BehaviorSystem() : base(Aspect.One(typeof(Behavior)).One(typeof(Position), typeof(Physics), typeof(Fighter)))
        {

        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _positionMapper = mapperService.GetMapper<Position>();
            _physicsmapper = mapperService.GetMapper<Physics>();
            _fighterMapper = mapperService.GetMapper<Fighter>();
        }

        public override void Process(GameTime gameTime, int entityId)
        {
            foreach (var e in ActiveEntities)
            {
                Behavior b = _behaviorMapper.Get(e);
                Position pos;
                Physics phy;
                Fighter f;

                try
                {
                    pos = _positionMapper.Get(e);
                    phy = _physicsmapper.Get(e);
                    f = _fighterMapper.Get(e);
                }
                catch
                {
                    return;
                }

                foreach (Condition c in b.IndependentConditions)
                {
                    switch (c.Type)
                    {
                        case ConditionType.PlayerShoot:
                            if (Game1.player.Get<Player>().didShootLastFrame)
                            {
                                foreach (Effect effect in c.Effects)
                                {

                                }
                            }
                    }
                }
            }
        }
    }
}
