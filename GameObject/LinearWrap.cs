using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using MahJong.Scrolling;

namespace MahJong.GameObject
{
    #region Resolution
    public static class Resolution
    {
        private static Vector3 ScalingFactor;
        private static int _preferredBackBufferWidth;
        private static int _preferredBackBufferHeight;

        /// <summary>
        /// The virtual screen size. Default is 1280x800. See the non-existent documentation on how this works.
        /// </summary>
        public static Vector2 VirtualScreen { get; set; }

        /// <summary>
        /// The screen scale
        /// </summary>
        public static Vector2 ScreenAspectRatio { get; set; }

        /// <summary>
        /// The scale used for beginning the SpriteBatch.
        /// </summary>
        public static Matrix Scale { get; set; }

        /// <summary>
        /// The scale result of merging VirtualScreen with WindowScreen.
        /// </summary>
        public static Vector2 ScreenScale { get; set; }

        /// <summary>
        /// Updates the specified graphics device to use the configured resolution.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <exception cref="System.ArgumentNullException">device</exception>
        public static void Update(GraphicsDeviceManager device)
        {
            if (device == null) throw new ArgumentNullException("device");

            //Calculate ScalingFactor
            _preferredBackBufferWidth = device.PreferredBackBufferWidth;
            float widthScale = _preferredBackBufferWidth / VirtualScreen.X;

            _preferredBackBufferHeight = device.PreferredBackBufferHeight;
            float heightScale = _preferredBackBufferHeight / VirtualScreen.Y;

            ScreenScale = new Vector2(widthScale, heightScale);

            ScreenAspectRatio = new Vector2(widthScale / heightScale);
            ScalingFactor = new Vector3(widthScale, heightScale, 1);
            Scale = Matrix.CreateScale(ScalingFactor);
            device.ApplyChanges();
        }

        /// <summary>
        /// <para>Determines the draw scaling.</para>
        /// <para>Used to make the mouse scale correctly according to the virtual resolution,
        /// no matter the actual resolution.</para>
        /// <para>Example: 1920x1080 applied to 1280x800: new Vector2(1.5f, 1,35f)</para>
        /// </summary>
        /// <returns></returns>
        public static Vector2 DetermineDrawScaling()
        {
            var x = _preferredBackBufferWidth / VirtualScreen.X;
            var y = _preferredBackBufferHeight / VirtualScreen.Y;
            return new Vector2(x, y);
        }
    }
    #endregion
    internal class LinearWrap : IDisposable
    {
        protected GraphicsDeviceManager graphics;
        protected GraphicsDevice graphicsDevice;
        protected GameWindow window;
        protected ContentManager content;
        //protected String sourceString = "Background/";
        //String contentString;

        public LinearWrap(MarioGame game)
        {
            graphics = game.Graphics;
            content = game.Content;
            graphicsDevice = game.GraphicsDevice;
            game.Content.RootDirectory = "Content";
            Resolution.VirtualScreen = new Vector2(1920, 1080);
            window = game.Window;
            graphicsDevice = game.GraphicsDevice;
            //this.contentString = this.sourceString + contentString;

        }

        public void Initialize()
        {
            window.AllowUserResizing = true;
            window.ClientSizeChanged += OnResized;
        }

        public void OnResized(Object sender, EventArgs args)
        {
            window.ClientSizeChanged -= OnResized;

            graphics.PreferredBackBufferWidth = window.ClientBounds.Width;
            graphics.PreferredBackBufferHeight = window.ClientBounds.Height;

            graphics.ApplyChanges();


            window.ClientSizeChanged += OnResized;
        }


        //protected void LoadContent()
        //{
        //    Create a new SpriteBatch, which can be used to draw textures.
        //   spriteBatch = new SpriteBatch(graphicsDevice);

        //}




        ///// <summary>
        ///// Allows the game to run logic such as updating the world,
        ///// checking for collisions, gathering input, and playing audio.
        ///// </summary>
        ///// <param name="gameTime">Provides a snapshot of timing values.</param>
        //public void Update(GameTime gameTime)
        //{
        //    Resolution.Update(graphics);
        //}



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        RenderTarget2D _renderTarget = null;

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            //graphicsDevice.Clear(Color.CornflowerBlue);

            // Create Render Target
            Point _dimension = new Point(960, 1300);
            if (_renderTarget == null)
                _renderTarget = new RenderTarget2D(graphicsDevice, _dimension.X, _dimension.Y);

            graphicsDevice.SetRenderTarget(_renderTarget);

            graphicsDevice.Clear(Color.CornflowerBlue);

            this.DrawContent(spriteBatch);

            // Reset the device to the back buffer
            graphicsDevice.SetRenderTarget(null);

            // Now Tile RenderTarget across ViewPort
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetViewMatrix(new Vector2(0.5f, 0.5f)));

            Viewport _viewport = graphicsDevice.Viewport;
            int _tilesX = 1;
            while ((_dimension.X * _tilesX) <= _viewport.Width)
                _tilesX++;
            _tilesX++;
            int _tilesY = 1;
            while ((_dimension.Y * _tilesY) <= _viewport.Width)
                _tilesY++;
            _tilesY++;

            for (int _tileY = 0; _tileY < _tilesY; _tileY++)
                for (int _tileX = 0; _tileX < _tilesX; _tileX++)
                    spriteBatch.Draw((Texture2D)_renderTarget, new Vector2(_tileX * _dimension.X, _tileY * _dimension.Y), new Rectangle(0, 0, _dimension.X, _dimension.Y), Color.White);

            spriteBatch.End();



            //base.Draw(gameTime);
        }

        private void DrawContent(SpriteBatch spriteBatch)
        {
            int ground = 380;
            String sourceString = "Background/clouds";

            spriteBatch.Begin();
            
            // Small Clouds
            spriteBatch.Draw(content.Load<Texture2D>(sourceString), new Vector2(285, 20), new Rectangle(5, 5, 64, 48), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
            spriteBatch.Draw(content.Load<Texture2D>(sourceString), new Vector2(585, 110), new Rectangle(5, 5, 64, 48), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);

            // Medium Clouds
            spriteBatch.Draw(content.Load<Texture2D>(sourceString), new Vector2(25, 140), new Rectangle(74, 5, 96, 48), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);

            // Large Clouds       
            spriteBatch.Draw(content.Load<Texture2D>(sourceString), new Vector2(770, 70), new Rectangle(174, 5, 128, 48), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);


            sourceString = "Background/Mountains";
            // Large grass
            spriteBatch.Draw(content.Load<Texture2D>(sourceString), new Vector2(885, ground), new Rectangle(0, 0, 110, 36), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);

            // Small grass
            spriteBatch.Draw(content.Load<Texture2D>(sourceString), new Vector2(370, ground), new Rectangle(110, 0, 110, 36), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);

            // Large mountain
            spriteBatch.Draw(content.Load<Texture2D>(sourceString), new Vector2(85, ground), new Rectangle(220, 0, 110, 36), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
            spriteBatch.Draw(content.Load<Texture2D>(sourceString), new Vector2(510, ground), new Rectangle(220, 0, 110, 36), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);

            // Small mountain
            spriteBatch.Draw(content.Load<Texture2D>(sourceString), new Vector2(725, ground), new Rectangle(330, 0, 110, 36), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);


            sourceString = "Background/Mountains_";
            int ground2 = 380;
            spriteBatch.Draw(content.Load<Texture2D>(sourceString), new Vector2(0, ground2), new Rectangle(133, 0, 141, 72), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
            spriteBatch.Draw(content.Load<Texture2D>(sourceString), new Vector2(260, ground2), new Rectangle(0, 0, 133, 72), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
            spriteBatch.Draw(content.Load<Texture2D>(sourceString), new Vector2(142, ground2), new Rectangle(133, 0, 141, 72), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
            spriteBatch.Draw(content.Load<Texture2D>(sourceString), new Vector2(320, ground2 - 5), new Rectangle(133, 0, 141, 72), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
            spriteBatch.Draw(content.Load<Texture2D>(sourceString), new Vector2(400, ground2), new Rectangle(133, 0, 141, 72), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
            spriteBatch.Draw(content.Load<Texture2D>(sourceString), new Vector2(587, ground2 - 3), new Rectangle(133, 0, 141, 72), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);

            spriteBatch.End();

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                _renderTarget.Dispose();
            }
            // free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}


