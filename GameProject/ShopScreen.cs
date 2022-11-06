using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    public class ShopScreen : screen
    {
        SpriteFont Coin;
        Game1 game;

        public ShopScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            Coin = game.Content.Load<SpriteFont>("monbar");
            this.game = game;
        }
        public override void Update(GameTime theTime)
        {
            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.DrawString(Coin, "coin", new Vector2(180, 100), Color.Red);
            base.Draw(theBatch);
        }
    }
}
