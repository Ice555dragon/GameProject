using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    public class SelectScreen : screen
    {
        Game1 game;
        Texture2D Mc_m, Mc_r, Mc_s,Exit,Class, menuTexture;
        Rectangle Mbox,Rbox,Sbox,HitE,HitM,HitR,HitS;
        Color EColor;
        int Select;
        MouseState mouse;
        
        public SelectScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            menuTexture = game.Content.Load<Texture2D>("BG_menu");
            Mc_m = game.Content.Load<Texture2D>("M_class");
            Mc_r = game.Content.Load<Texture2D>("R_class");
            Mc_s = game.Content.Load<Texture2D>("S_class");
            Exit = game.Content.Load<Texture2D>("exit");
            Class = game.Content.Load<Texture2D>("Class_UI");

            HitM = new Rectangle(50, 300, 200, 315);
            HitR = new Rectangle(500, 300, 200, 315);
            HitS = new Rectangle(1000, 300, 200, 315);
            HitE = new Rectangle(0, 0, 100, 85);

            EColor = Color.White;
            this.game = game;
        }
        public override void Update(GameTime theTime)
        {                      
            mouse = Mouse.GetState();
            GetSelect();
            if(HitM.Contains(mouse.X, mouse.Y))
            {
                Mbox = new Rectangle(200, 0, 200, 315);
            }
            else 
            {
                Mbox = new Rectangle(0, 0, 200, 315);
            }
            if (HitR.Contains(mouse.X, mouse.Y))
            {
                Rbox = new Rectangle(200, 0, 200, 315);
            }
            else
            {
                Rbox = new Rectangle(0, 0, 200, 315);
            }
            if (HitS.Contains(mouse.X, mouse.Y))
            {
                Sbox = new Rectangle(200, 0, 200, 315);
            }
            else
            {
                Sbox = new Rectangle(0, 0, 200, 315);
            }
            if (HitE.Contains(mouse.X, mouse.Y))
            {
                EColor = Color.Gray;
            }
            else
            {
                EColor = Color.White;
            }

            if (HitE.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                ScreenEvent.Invoke(game.mTitleScreen, new EventArgs());
                return;
            }
            //Select
            if (HitM.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                Select = 1;
                GetSelect();
                ScreenEvent.Invoke(game.mGameplayScreen, new EventArgs());
                return;
            }
            else if (HitR.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                Select = 2;
                GetSelect();
                ScreenEvent.Invoke(game.mGameplayScreen, new EventArgs());
                return;
            }
            else if (HitS.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                Select = 3;
                GetSelect();
                ScreenEvent.Invoke(game.mGameplayScreen, new EventArgs());
                return;
            }


            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(menuTexture, Vector2.Zero, Color.White);
            theBatch.Draw(Mc_m, new Vector2(50,300),Mbox, Color.White);
            theBatch.Draw(Mc_r, new Vector2(500, 300), Rbox, Color.White);
            theBatch.Draw(Mc_s, new Vector2(1000, 300), Sbox, Color.White);
            theBatch.Draw(Exit, Vector2.Zero,EColor);
            theBatch.Draw(Class,new Vector2(400,0), Color.White);
            base.Draw(theBatch);
        }
        public void GetSelect()
        {
            Store.SelectMc = Select;
        }
    }
}
