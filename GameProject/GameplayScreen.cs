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
        Texture2D test,EN_d,EN_r,EN_b,EN_m,EN_mb;
        Texture2D matchTexture, matchBG,BG,Mc_m,Mc_r,Mc_s;
        SpriteFont Monbar;
        int monHealth,playerHealth,MaxHealth;
        int exp, shield, atk, Lv, maxExp, gainExp;
        int coin;
        int EN_select,stage,monAtk;
        Vector2 playerposition,enpositon;
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
            EN_m = game.Content.Load<Texture2D>("EN_m");
            EN_r = game.Content.Load<Texture2D>("EN_r");
            EN_mb = game.Content.Load<Texture2D>("EN_mb");
            EN_b = game.Content.Load<Texture2D>("EN_b");
            EN_d = game.Content.Load<Texture2D>("EN_d");

            comboTest = Color.White;          
            playerHealth = 1500;
            coin = 0;
            exp = 0;
            shield = 0;
            atk = 15;
            EN_select = 1;
            stage = 0;
            Lv = 1;
            maxExp = 100;
            playerposition = new Vector2(180, 240);
            enpositon = new Vector2(1020, 240);
            gainExp = 10;
            MaxHealth = 1500;
            

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
            

            //spawn enemy
            if (monHealth <= 0 && stage < 4)
            {
                EN_select = r.Next(1, 4);
                if (EN_select == 1)
                {
                    monHealth = 1500;
                    monAtk = 15;
                }
                else if (EN_select == 2)
                {
                    monHealth = 2500;
                    monAtk = 10;
                }
                else if (EN_select == 3)
                {
                    monHealth = 1000;
                    monAtk = 25;
                }
                stage++;
            }
            else if (monHealth <= 0 && stage == 4)
            {
                monHealth = 3500;
                monAtk = 25;
                EN_select = 4;
                stage++;
            }
            else if (monHealth <= 0 && stage > 4 && stage < 9)
            {
                EN_select = r.Next(1, 4);
                if (EN_select == 1)
                {
                    monHealth = 1500;
                    monAtk = 15;
                }
                else if (EN_select == 2)
                {
                    monHealth = 2500;
                    monAtk = 10;
                }
                else if (EN_select == 3)
                {
                    monHealth = 1000;
                    monAtk = 25;
                }
                stage++;
            }
            else if (monHealth <= 0 && stage == 9)
            {
                monHealth = 5000;
                monAtk = 35;
                EN_select = 5;
                stage++;
            }    

            //Level up
            if (exp >= maxExp)
            {
                exp = 0;
                maxExp += 200;
                atk += 5;
                coin += 50;
                playerHealth += 100;
                MaxHealth += 100;
                Lv++;
            }
            else if(Lv > 15&& exp >= maxExp)
            {
                exp = 0;
                coin += 50;
                playerHealth += 100;
            }

            //win/lose
            if (playerHealth <= 0)
            {
                stage = 0;
                Lv = 1;
                maxExp = 100;
                exp = 0;
            }
            else if (monHealth <= 0 && stage > 9)
            {
                stage = 0;
                exp = 0;
                Lv = 1;
                maxExp = 100;
                ScreenEvent.Invoke(game.mWinScreen, new EventArgs());
                return;
            }
           


            if (ks.IsKeyDown(Keys.R) == true)
            {
                atk = 9999;
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
                if (blockHit[i].Contains(mouse.X, mouse.Y))
                {
                    select = Type[i];
                    for (int j = 0; j < 60; j++)
                    {
                        if (Type[j] == select)
                        {
                            MatchColor[j] = Color.Gray;
                        }                    
                    }
                }
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
                    monHealth -= combo * atk;
                }
                else if (select == 2)
                {
                    if (playerHealth < MaxHealth)
                    {
                        playerHealth += combo;
                    }
                    else
                    {
                        playerHealth = MaxHealth;
                    }                   
                }
                else if (select == 3)
                {
                    shield += combo;
                }
                else if (select == 4)
                {
                    coin += combo;
                }
                else if (select == 5)
                {
                    exp += combo * gainExp;
                }
                //reset combo
                if (blockHit[i].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && Premouse.LeftButton == ButtonState.Released)
                {
                    combo = 0;
                }              
            }
            
            

        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(test, Vector2.Zero, Color.White);
            theBatch.Draw(BG, Vector2.Zero, Color.White);
            theBatch.Draw(matchBG, new Vector2(0, 360), comboTest);
            //match
            for (int i = 0; i < 60; i++)
            {
                theBatch.Draw(matchTexture, position[i], TypeSelect[i], MatchColor[i]);
            }
            theBatch.Draw(Mc_m,playerposition,Color.White);
            //enemy
            if (EN_select == 1)
            {
                theBatch.Draw(EN_m, enpositon, Color.White);
            }
            else if (EN_select == 2)
            {
                theBatch.Draw(EN_d, enpositon, Color.White);
            }
            else if (EN_select == 3)
            {
                theBatch.Draw(EN_r, enpositon, Color.White);
            }
            else if (EN_select == 4)
            {
                theBatch.Draw(EN_mb, enpositon, Color.White);
            }
            else if (EN_select == 5)
            {
                theBatch.Draw(EN_b, enpositon, Color.White);
            }

            theBatch.DrawString(Monbar,"monsterHealth = " + monHealth.ToString(), new Vector2(1020, 150), Color.Red);
            theBatch.DrawString(Monbar, "playerHealth = " + playerHealth.ToString(), new Vector2(180, 150), Color.Red);
            theBatch.DrawString(Monbar, "coin = " + coin.ToString(), new Vector2(180, 100), Color.Red);
            theBatch.DrawString(Monbar, "Exp = " + exp.ToString(), new Vector2(180, 115), Color.Red);
            theBatch.DrawString(Monbar, "stage = " + stage.ToString(), new Vector2(0, 0), Color.Red);
            theBatch.DrawString(Monbar, "Level = " + Lv.ToString(), new Vector2(0, 50), Color.Red);
            base.Draw(theBatch);
        }
    }
}
