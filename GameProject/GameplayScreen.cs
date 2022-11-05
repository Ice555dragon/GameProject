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
        Texture2D matchTexture, matchBG,BG,Mc_m,Mc_r,Mc_s;
        SpriteFont Monbar;
        int monHealth,playerHealth,coin,exp,shield;       
        int[] Type = new int[60];
        MouseState mouse, Premouse;
        Vector2[] position = new Vector2[60];
        Rectangle[] blockHit = new Rectangle[60];
        Rectangle[] TypeSelect = new Rectangle[60];
        Color comboTest;
        Color[] MatchColor = new Color[60];
        int select, combo = 0;
        public GameplayScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            test = game.Content.Load<Texture2D>("Test");
            matchTexture = game.Content.Load<Texture2D>("Match");
            matchBG = game.Content.Load<Texture2D>("matchBG");
            Monbar = game.Content.Load<SpriteFont>("monbar");
            BG = game.Content.Load<Texture2D>("bg");
            Mc_m = game.Content.Load<Texture2D>("Mc_m");
            Mc_r = game.Content.Load<Texture2D>("Mc_r");
            Mc_s = game.Content.Load<Texture2D>("Mc_s");

            comboTest = Color.White;
            monHealth = 100;
            playerHealth = 100;
            coin = 0;
            exp = 0;
            shield = 0;

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
            
            KeyboardState ks = Keyboard.GetState();
            if (monHealth <= 0)
            {
                playerHealth = 100;
                monHealth = 100;
                exp = 0;
                ScreenEvent.Invoke(game.mSelectScreen, new EventArgs());
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
                //Select Check
                if (select == 1)
                {
                    //combocheck
                    monHealth -= combo;
                }
                else if (select == 2)
                {
                    coin += combo;
                }
                else if (select == 3)
                {
                    shield += combo;
                }
                else if (select == 4)
                {
                    exp += combo;
                }
                else if (select == 5)
                {
                    if(playerHealth < 150)
                    {
                        playerHealth += combo;
                    }
                    else
                    {
                        playerHealth = 150;
                    }
                    
                }
                //reset combo
                if (blockHit[i].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && Premouse.LeftButton == ButtonState.Released)
                {
                    combo = 0;
                }              
            }
            
            
            
            //reset combocheck
            if (ks.IsKeyDown(Keys.R) == true)
            {
                comboTest = Color.White;
            }
            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(test, Vector2.Zero, Color.White);
            theBatch.Draw(BG, Vector2.Zero, Color.White);
            theBatch.Draw(matchBG, new Vector2(0, 360), comboTest);
            for (int i = 0; i < 60; i++)
            {
                theBatch.Draw(matchTexture, position[i], TypeSelect[i], MatchColor[i]);
            }
            theBatch.DrawString(Monbar,"monsterHealth = " + monHealth.ToString(), new Vector2(1020, 150), Color.Red);
            theBatch.DrawString(Monbar, "playerHealth = " + playerHealth.ToString(), new Vector2(180, 150), Color.Red);
            theBatch.DrawString(Monbar, "coin = " + coin.ToString(), new Vector2(180, 100), Color.Red);
            theBatch.DrawString(Monbar, "Exp = " + exp.ToString(), new Vector2(180, 115), Color.Red);
            base.Draw(theBatch);
        }
    }
}
