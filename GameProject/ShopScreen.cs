using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    class ShopScreen : screen
    {
        Game1 game;
        public ShopScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;
        }
        public override void Update(GameTime theTime)
        {
            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            base.Draw(theBatch);
        }
    }
}
