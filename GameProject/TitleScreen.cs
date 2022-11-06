using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    public class TitleScreen : screen
    {
        Texture2D menuTexture,logo,start_btn,shop_btn;
        Rectangle startBox, shopBox, Hitstart, Hitshop;
        Game1 game;
        MouseState mouse,Premouse;
        public TitleScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            menuTexture = game.Content.Load<Texture2D>("BG_menu");
            logo = game.Content.Load<Texture2D>("logo");
            start_btn = game.Content.Load<Texture2D>("START");
            shop_btn = game.Content.Load<Texture2D>("SHOP");

            Hitstart = new Rectangle(450, 300, 400, 100);
            Hitshop = new Rectangle(450, 500, 400, 100);

            this.game = game;
        }
        public override void Update(GameTime theTime)
        {
            Premouse = mouse;
            mouse = Mouse.GetState();
            if (Hitstart.Contains(mouse.X, mouse.Y))
            {
                startBox = new Rectangle(400, 0, 400, 100);
            }
            else
            {
                startBox = new Rectangle(0, 0, 400, 100);
            }
            if (Hitshop.Contains(mouse.X, mouse.Y))
            {
                shopBox = new Rectangle(400, 0, 400, 100);
            }
            else
            {
                shopBox = new Rectangle(0, 0, 400, 100);
            }

            if (Hitstart.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && Premouse.LeftButton == ButtonState.Released)
            {
                ScreenEvent.Invoke(game.mSelectScreen, new EventArgs());
                return;
            }
            if (Hitshop.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && Premouse.LeftButton == ButtonState.Released)
            {
                ScreenEvent.Invoke(game.mShopScreen, new EventArgs());
                return;
            }
            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(menuTexture, Vector2.Zero, Color.White);
            theBatch.Draw(logo, new Vector2(360, 50), Color.White);
            theBatch.Draw(start_btn, new Vector2(450, 300), startBox, Color.White);
            theBatch.Draw(shop_btn, new Vector2(450, 500), shopBox, Color.White);
            base.Draw(theBatch);
        }
    }
}
