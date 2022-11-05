using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace GameProject
{
    public class Game1 : Game
    {
        
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public screen mCurrentScreen;
        public GameplayScreen mGameplayScreen;
        public TitleScreen mTitleScreen;
        public SelectScreen mSelectScreen;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1272;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            mGameplayScreen = new GameplayScreen(this, new EventHandler(GameplayScreenEvent));
            mTitleScreen = new TitleScreen(this, new EventHandler(GameplayScreenEvent));
            mSelectScreen = new SelectScreen(this, new EventHandler(GameplayScreenEvent));
            mCurrentScreen = mGameplayScreen;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mCurrentScreen.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Purple);
            _spriteBatch.Begin();
            mCurrentScreen.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        public void GameplayScreenEvent(object obj, EventArgs e)
        {
            mCurrentScreen = (screen)obj;
        }

    }
}
