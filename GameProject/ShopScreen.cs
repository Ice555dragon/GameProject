using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    public class ShopScreen : screen
    {
        SpriteFont Text;
        Game1 game;
        Texture2D menuTexture, Exit,UI,Item;
        MouseState mouse;
        Rectangle HitE,Head,Chest,Gun,Arm,Leg,Core;
        Rectangle HitHead, HitChest, HitGun, HitArm, HitLeg, HitCore;
        Color EColor;
        int coin;
        public void GetCoin()
        {
            coin = Store.Coin;
        }
        public ShopScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            menuTexture = game.Content.Load<Texture2D>("BG_menu");
            Text = game.Content.Load<SpriteFont>("monbar");
            Exit = game.Content.Load<Texture2D>("exit");
            UI = game.Content.Load<Texture2D>("SHOP_UI");
            Item = game.Content.Load<Texture2D>("item");

            HitE = new Rectangle(0, 0, 100, 85);
            HitHead = new Rectangle(10, 160, 150, 150);
            HitGun = new Rectangle(10, 320, 150, 150);
            HitArm = new Rectangle(10, 480, 150, 150);
            HitCore = new Rectangle(180, 160, 150, 150);
            HitLeg = new Rectangle(180, 320, 150, 150);
            HitChest = new Rectangle(180, 480, 150, 150);

            
            Gun = new Rectangle(0, 150, 150, 150);
            Arm = new Rectangle(0, 300, 150, 150);
            Core = new Rectangle(0, 450, 150, 150);
            Leg = new Rectangle(0, 600, 150, 150);
            Chest = new Rectangle(0, 750, 150, 150);

            this.game = game;
        }
        public override void Update(GameTime theTime)
        {
            mouse = Mouse.GetState();
            GetCoin();
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
            //Armor
            if(HitHead.Contains(mouse.X,mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                Head = new Rectangle(150, 0, 150, 150);
            }
            else
            {
                Head = new Rectangle(0, 0, 150, 150);
            }

            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            
            theBatch.Draw(menuTexture, Vector2.Zero, Color.White);
            theBatch.Draw(UI, new Vector2(400, 50), Color.White);
            theBatch.DrawString(Text, "coin " + coin.ToString(), new Vector2(180, 100), Color.Red);
            theBatch.Draw(Exit, Vector2.Zero, EColor);
            theBatch.Draw(Item, new Vector2(10, 160), Head, Color.White);
            theBatch.Draw(Item, new Vector2(10, 320), Gun, Color.White);
            theBatch.Draw(Item, new Vector2(10, 480), Arm, Color.White);
            theBatch.Draw(Item, new Vector2(180, 160), Leg, Color.White);
            theBatch.Draw(Item, new Vector2(180, 320), Core, Color.White);
            theBatch.Draw(Item, new Vector2(180, 480), Chest, Color.White);
            base.Draw(theBatch);
        }
       
    }
}
