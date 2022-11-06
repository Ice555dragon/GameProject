using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    public class SelectScreen : screen
    {
        Game1 game;
        Texture2D Mc_m, Mc_r, Mc_s;
        int Select = 0;
        MouseState mouse, Premouse;
        public SelectScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            Mc_m = game.Content.Load<Texture2D>("Mc_m");
            Mc_r = game.Content.Load<Texture2D>("Mc_r");
            Mc_s = game.Content.Load<Texture2D>("Mc_s");
            this.game = game;
        }
        public override void Update(GameTime theTime)
        {           
            Premouse = mouse;
            mouse = Mouse.GetState();
            
            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(Mc_m, new Vector2(0,120), Color.White);
            base.Draw(theBatch);
        }

       
    }
}
