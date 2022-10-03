using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    public class TitleScreen : screen
    {
        Texture2D menuTexture;
        Game1 game;
        MouseState mouse,Premouse;
        public TitleScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            menuTexture = game.Content.Load<Texture2D>("start");
            this.game = game;
        }
        public override void Update(GameTime theTime)
        {
            Premouse = mouse;
            mouse = Mouse.GetState();
            if (mouse.LeftButton == ButtonState.Pressed && Premouse.LeftButton == ButtonState.Released)
            {
                ScreenEvent.Invoke(game.mGameplayScreen, new EventArgs());
                return;
            }
            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(menuTexture, Vector2.Zero, Color.White);
            base.Draw(theBatch);
        }

    }
}
