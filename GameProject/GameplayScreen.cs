using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    public class GameplayScreen : screen
    {
        Random r = new Random();
        Game1 game;
        Texture2D test;
        Texture2D matchTexture, matchBG;
        MouseState mouse;
        MouseState Premouse;
        int[] Type = new int[60];
        Vector2[] position = new Vector2[60];
        Rectangle[] blockHit = new Rectangle[60];
        Rectangle[] TypeSelect = new Rectangle[60];
        Color TestColor, comboTest;
        Color[] MatchColor = new Color[60];
        int select, combo = 0;
        public GameplayScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            test = game.Content.Load<Texture2D>("Test");
            matchTexture = game.Content.Load<Texture2D>("Match");
            matchBG = game.Content.Load<Texture2D>("matchBG");
            TestColor = Color.White;
            comboTest = Color.White;

            //spawn all match3
            int count = 0;
            for (int i = 0; i < 12; i++)
            {
                position[i] = new Vector2(203 + (72 * i), 360);
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
            for (int i = 0; i < 60; i++)
            {
                blockHit[i] = new Rectangle((int)position[i].X, (int)position[i].Y, 72, 72);
            }

            //random
            for (int i = 0; i < 60; i++)
            {
                Type[i] = r.Next(1, 6);
                if (Type[i] == 1)
                {
                    TypeSelect[i] = new Rectangle(0, 0, 72, 72);
                }
                else if (Type[i] == 2)
                {
                    TypeSelect[i] = new Rectangle(72, 0, 72, 72);
                }
                else if (Type[i] == 3)
                {
                    TypeSelect[i] = new Rectangle(72 * 2, 0, 72, 72);
                }
                else if (Type[i] == 4)
                {
                    TypeSelect[i] = new Rectangle(72 * 3, 0, 72, 72);
                }
                else if (Type[i] == 5)
                {
                    TypeSelect[i] = new Rectangle(72 * 4, 0, 72, 72);
                }
            }
            this.game = game;
        }
        public override void Update(GameTime theTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.B) == true)
            {
                ScreenEvent.Invoke(game.mTitleScreen, new EventArgs());
                return;
            }
            Premouse = mouse;
            mouse = Mouse.GetState();

            for (int i = 0; i < 60; i++)
            {
                MatchColor[i] = Color.White;
            }

            //click code
            for (int i = 0; i < 60; i++)
            {
                if (blockHit[i].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && Premouse.LeftButton == ButtonState.Released)
                {
                    select = Type[i];
                    //change box + combo
                    for (int j = 0; j < 60; j++)
                    {
                        if (Type[j] == select)
                        {
                            combo++;
                            Type[j] = r.Next(1, 6);
                            if (Type[j] == 1)
                            {
                                TypeSelect[j] = new Rectangle(0, 0, 72, 72);
                                MatchColor[j] = Color.Red;
                            }
                            else if (Type[j] == 2)
                            {
                                TypeSelect[j] = new Rectangle(72, 0, 72, 72);
                                MatchColor[j] = Color.Red;
                            }
                            else if (Type[j] == 3)
                            {
                                TypeSelect[j] = new Rectangle(72 * 2, 0, 72, 72);
                                MatchColor[j] = Color.Red;
                            }
                            else if (Type[j] == 4)
                            {
                                TypeSelect[j] = new Rectangle(72 * 3, 0, 72, 72);
                                MatchColor[j] = Color.Red;
                            }
                            else if (Type[j] == 5)
                            {
                                TypeSelect[j] = new Rectangle(72 * 4, 0, 72, 72);
                                MatchColor[j] = Color.Red;
                            }
                        }
                    }
                }
                //combocheck
                if (combo > 20)
                {
                    comboTest = Color.Pink;
                }
                if (blockHit[i].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && Premouse.LeftButton == ButtonState.Released)
                {
                    combo = 0;
                }               
            }
            //reset combocheck
            if (Keyboard.GetState().IsKeyDown(Keys.R) == true)
            {
                comboTest = Color.White;
            }
            //Select Check
            if (select == 1)
            {
                TestColor = Color.Red;
            }
            else if (select == 2)
            {
                TestColor = Color.Blue;
            }
            else if (select == 3)
            {
                TestColor = Color.Green;
            }
            else if (select == 4)
            {
                TestColor = Color.Yellow;
            }
            else if (select == 5)
            {
                TestColor = Color.Purple;
            }
            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(test, Vector2.Zero, TestColor);
            theBatch.Draw(matchBG, new Vector2(0, 360), comboTest);
            for (int i = 0; i < 60; i++)
            {
                theBatch.Draw(matchTexture, position[i], TypeSelect[i], MatchColor[i]);
            }
            base.Draw(theBatch);
        }
    }
}
