using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace PlatformerTest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private World _world;
        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            //Setting screen size
            base.Initialize();
            _graphics.PreferredBackBufferHeight = 1080; //Screen width
            _graphics.PreferredBackBufferWidth = 1920; //Screen height
            _graphics.ApplyChanges();

            //Setting the default room and adding all of the systems
            _world = new WorldBuilder()
                .AddSystem(new RenderSystem(_graphics.GraphicsDevice)) //Passing in the graphics device to the rendering system
                .AddSystem(new PositionSystem())
                .AddSystem(new PhysicsSystem())
                .AddSystem(new PlayerSystem())
                .Build();
            Components.Add(_world);

            //Creating the player entity, this is all moving into a separate entity factory class soon.
            var entity = _world.CreateEntity();
            entity.Attach(new Player());
            var p = new Physics();
            p.xAcceleration = 1.9f;
            p.xAirAcceleration = 1.7f;
            p.velocityMod = 0.85f;
            entity.Attach(p);
            entity.Attach(new Position(new Vector2(150f, 150f)));
            entity.Attach(new Render(Content.Load<Texture2D>("Retro Mario")));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _tiledMap = Content.Load<TiledMap>("room1");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //Calling all world system update methods
            _world.Update(gameTime);
            _tiledMapRenderer.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Calling all world system draw methods
            _world.Draw(gameTime);
            _tiledMapRenderer.Draw();
            base.Draw(gameTime);
        }
    }
}
