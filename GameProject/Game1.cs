using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace GameProject
{
    public class Game1 : Game
    {
        Random r = new Random();
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D test;
        Texture2D matchTexture;
        MouseState mouse;
        MouseState Premouse;
        int[] Type = new int[60];
        Vector2[] position = new Vector2[60];        
        Rectangle[] blockHit = new Rectangle[60];
        Rectangle[] TypeSelect = new Rectangle[60];
        Color[] MatchColor = new Color[60];
        int select;

        

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
            test = Content.Load<Texture2D>("Test");
            matchTexture = Content.Load<Texture2D>("Match");

            //spawn all match3
            int count = 0;
           for (int i = 0; i < 12; i++)
            {
                position[i] = new Vector2(203+(72*i), 360);
            }
           for (int i = 12; i < 24; i++)
           {
                position[i] = new Vector2(203 + (72 * count), 432);
                count++;
           }
            count = 0;
            for (int i = 24; i < 36; i++)
            {
                position[i] = new Vector2(203 + (72 * count), 504);
                count++;
            }
            count = 0;
            for (int i = 36; i < 48; i++)
            {
                position[i] = new Vector2(203 + (72 * count), 576);
                count++;
            }
            count = 0;
            for (int i = 48; i < 60; i++)
            {
                position[i] = new Vector2(203 + (72 * count), 648);
                count++;
            }
            for (int i = 0;i<60; i++) 
            {
                blockHit[i] = new Rectangle((int)position[i].X, (int)position[i].Y, 72, 72);
            }
            
            //random
            for(int i = 0;i < 60; i++)
            {
                Type[i] = r.Next(1, 6);
                if(Type[i] == 1)
                {
                    TypeSelect[i] = new Rectangle(0, 0, 72, 72);
                }
                else if (Type[i] == 2)
                {
                    TypeSelect[i] = new Rectangle(72, 0, 72, 72);
                }
                else if (Type[i] == 3)
                {
                    TypeSelect[i] = new Rectangle(72*2, 0, 72, 72);
                }
                else if (Type[i] == 4)
                {
                    TypeSelect[i] = new Rectangle(72*3, 0, 72, 72);
                }
                else if (Type[i] == 5)
                {
                    TypeSelect[i] = new Rectangle(72*4, 0, 72, 72);
                }
            }

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Premouse = mouse;
            mouse = Mouse.GetState();

            //swap code
           for(int i = 0;i<60; i++)
            {
                MatchColor[i] = Color.White;

                if (blockHit[i].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && Premouse.LeftButton == ButtonState.Released)
                {
                    select = Type[i];
                }
            }
            for (int i = 0; i < 60; i++)
            {
                if(Type[i] == select)
                {
                    MatchColor[i] = Color.Blue;
                }
            }

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(test, Vector2.Zero, Color.White);
            
            for (int i = 0; i < 60; i++)
            {                  
                    _spriteBatch.Draw(matchTexture, position[i],TypeSelect[i], MatchColor[i]);                         
            }         
            _spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
