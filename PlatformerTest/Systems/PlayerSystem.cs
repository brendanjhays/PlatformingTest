using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended;
using Microsoft.Xna.Framework.Input;

namespace PlatformerTest
{
    class PlayerSystem : EntityProcessingSystem
    {
        private ComponentMapper<Physics> _physicsMapper;
        private ComponentMapper<Render> _renderMapper;
        private ComponentMapper<Player> _playerMapper;
        private ComponentMapper<Position> _positionMapper;

        //Stores last frame keyboard as well as current frame
        private KeyboardState _oldKeyboardState;
        private KeyboardState _newKeyboardState;

        private bool _storedFacing;
        public PlayerSystem() : base(Aspect.All(typeof(Player)))
        {

        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _physicsMapper = mapperService.GetMapper<Physics>();
            _playerMapper = mapperService.GetMapper<Player>();
            _renderMapper = mapperService.GetMapper<Render>();
            _positionMapper = mapperService.GetMapper<Position>();
        }

        public override void Process(GameTime gameTime, int entityId)
        {
            Physics physics = _physicsMapper.Get(entityId);
            Render render = _renderMapper.Get(entityId);
            Player player = _playerMapper.Get(entityId);
            Position position = _positionMapper.Get(entityId);

            _oldKeyboardState = _newKeyboardState;
            _newKeyboardState = Keyboard.GetState();

            if (_newKeyboardState.IsKeyDown(Keys.Right))
            {
                //Player accelerating to right
                if (player.storedFacing == false || player.dashTurnaroundTimer == 0)
                {
                    if (player.onGround) physics.velocity.X += physics.xAcceleration;
                    else physics.velocity.X += physics.xAirAcceleration;
                    player.facingLeft = false;
                }
            }

            if (_newKeyboardState.IsKeyDown(Keys.Left))
            {
                //Player accelerating to left
                if (player.storedFacing == true || player.dashTurnaroundTimer == 0)
                {
                    if (player.onGround) physics.velocity.X -= physics.xAcceleration;
                    else physics.velocity.X -= physics.xAirAcceleration;
                    player.facingLeft = true;
                }
                
            }

            if (_newKeyboardState.IsKeyDown(Keys.LeftShift) && player.dashTimer == 0)
            {
                //Dash mechanic, multiplies current velocity and starts cooldown timer
                physics.velocity.X *= 4;
                player.dashTimer = 120;
                player.dashTurnaroundTimer = 22;
                player.storedFacing = player.facingLeft;
                player.frenzyNeeded -= 1;
            }

            if (player.onGround && player.jumpTimer == 0 && _newKeyboardState.IsKeyDown(Keys.Space))
            {
                //Jumping, upward velocity set, changes grounded status, starts jump cooldown timer
                physics.velocity.Y -= 10f;
                player.onGround = false;
                player.jumpTimer = 20;
            }

            if (!player.onGround)
            {
                //Applying gravity
                physics.velocity.Y += 0.23f;
            }

            if (player.frenzyNeeded == 0)
            {
                player.frenzyTimer = 480;
                physics.xAcceleration *= 3f;
                player.frenzyNeeded = player.maxFrenzy;
            }

            if (player.frenzyTimer == 1)
            {
                physics.xAcceleration *= 0.25f;
            }

            //Smoothing x velocity
            physics.velocity.X *= physics.velocityMod;

            //Updating timers
            if (player.dashTimer > 0) player.dashTimer--;
            if (player.frenzyTimer > 0) player.frenzyTimer--;
            if (player.jumpTimer > 0) player.jumpTimer--;
            if (player.dashTurnaroundTimer > 0) player.dashTurnaroundTimer--;
            if (player.frenzyTimer > 0) player.frenzyTimer--;
        }
    }
}
