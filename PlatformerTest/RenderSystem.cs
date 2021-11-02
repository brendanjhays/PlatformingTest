using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended.Entities.Systems;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Entities;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace PlatformerTest
{
    class RenderSystem : EntityDrawSystem
    {
        private GraphicsDevice _graphicsDevice;
        private SpriteBatch _spriteBatch;
        private ComponentMapper<Render> _renderMapper;
        private ComponentMapper<Position> _positionMapper;
        public RenderSystem(GraphicsDevice graphicsDevice) : base(Aspect.All(typeof(Position), typeof(Render)))
        {
            _graphicsDevice = graphicsDevice;
            _spriteBatch = new SpriteBatch(_graphicsDevice);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _graphicsDevice.Clear(Color.Beige);
            foreach (var e in ActiveEntities)
            {
                Position p = _positionMapper.Get(e);
                Render r = _renderMapper.Get(e);
                _spriteBatch.Draw(r.sprite, p.position, Color.White);
            }
            _spriteBatch.End();
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _renderMapper = mapperService.GetMapper<Render>();
            _positionMapper = mapperService.GetMapper<Position>();
        }
    }
}
