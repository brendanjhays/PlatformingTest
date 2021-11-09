using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace PlatformerTest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private World _world;
        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;
        private OrthographicCamera _camera;
        private EntityFactory _entityFactory;

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

            var viewportadapter = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 600);
            _camera = new OrthographicCamera(viewportadapter);

            //Setting the default room and adding all of the systems
            _world = new WorldBuilder()
                .AddSystem(new RenderSystem(_graphics.GraphicsDevice)) //Passing in the graphics device to the rendering system
                .AddSystem(new PositionSystem())
                .AddSystem(new PhysicsSystem())
                .AddSystem(new PlayerSystem())
                .Build();
            Components.Add(_world);

            _entityFactory = new EntityFactory(_world, Content);

            //Creating the player entity, this is all moving into a separate entity factory class soon.
            _entityFactory.CreatePlayer(new Vector2(150f, 150f));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _tiledMap = Content.Load<TiledMap>("roomtrial");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);

            /*foreach (var tileLayer in _tiledMap.TileLayers)
            {
                for (var x = 0; x < tileLayer.Width; x++)
                {
                    for (var y = 0; y < tileLayer.Height; y++)
                    {
                        var tile = tileLayer.GetTile((ushort)x, (ushort)y);

                        if (tile.GlobalIdentifier == 1)
                        {
                            var tileWidth = 16;
                            var tileHeight = 16;
                            _entityFactory.CreateTile(new Vector2(x, y), new Vector2(tileWidth, tileHeight));
                        }
                    }
                }
            } */
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //Calling all world system update methods
            _world.Update(gameTime);
            _camera.LookAt(_camera.Position);
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
