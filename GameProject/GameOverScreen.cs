using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    public class GameOverScreen : screen
    {
        Game1 game;
        Texture2D winscreen, restart_btn, menu_btn, menuTexture;
        Rectangle restartBox, MenuBox, Hitrestart, HitMenu;
        MouseState mouse, Premouse;
        public GameOverScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            menuTexture = game.Content.Load<Texture2D>("BG_menu");
            winscreen = game.Content.Load<Texture2D>("Game_over");
            restart_btn = game.Content.Load<Texture2D>("Restart");
            menu_btn = game.Content.Load<Texture2D>("Menu");

            Hitrestart = new Rectangle(400, 400, 400, 100);
            HitMenu = new Rectangle(400, 600, 400, 100);


            this.game = game;
        }
        public override void Update(GameTime theTime)
        {
            Premouse = mouse;
            mouse = Mouse.GetState();
            if (Hitrestart.Contains(mouse.X, mouse.Y))
            {
                restartBox = new Rectangle(400, 0, 400, 100);
            }
            else
            {
                restartBox = new Rectangle(0, 0, 400, 100);
            }
            if (HitMenu.Contains(mouse.X, mouse.Y))
            {
                MenuBox = new Rectangle(400, 0, 400, 100);
            }
            else
            {
                MenuBox = new Rectangle(0, 0, 400, 100);
            }

            if (mouse.LeftButton == ButtonState.Pressed && Premouse.LeftButton == ButtonState.Released && Hitrestart.Contains(mouse.X, mouse.Y))
            {
                ScreenEvent.Invoke(game.mGameplayScreen, new EventArgs());
                return;
            }
            else if (mouse.LeftButton == ButtonState.Pressed && Premouse.LeftButton == ButtonState.Released && HitMenu.Contains(mouse.X, mouse.Y))
            {
                ScreenEvent.Invoke(game.mTitleScreen, new EventArgs());
                return;
            }
            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(menuTexture, Vector2.Zero, Color.White);
            theBatch.Draw(winscreen, new Vector2(375, 150), Color.White);
            theBatch.Draw(restart_btn, new Vector2(400, 400), restartBox, Color.White);
            theBatch.Draw(menu_btn, new Vector2(400, 600), MenuBox, Color.White);
            base.Draw(theBatch);
        }
    }
}