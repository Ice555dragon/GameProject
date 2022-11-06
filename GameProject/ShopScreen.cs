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
        Texture2D menuTexture, Exit,UI,Item,Upgrade,Symbol;
        MouseState mouse,premouse;
        Rectangle HitE,Head,Chest,Gun,Arm,Leg,Core;
        Rectangle HitHead, HitChest, HitGun, HitArm, HitLeg, HitCore;
        Rectangle HitH, HitAtk, HitExp, HitCoin, HitShield;
        bool IsHead, IsChest, IsGun, IsArm, IsLeg, IsCore;
        Color EColor,HColor,AtkColor,ExpColor,CoinColor,ShieldColor;
        int coin,HLv,AtkLv,ExpLv,CoinLv,ShieldLv;

        public void GetHLv()
        {
            Store.HLv = HLv;
        }
        public void GetExpLv()
        {
            Store.ExpLv = ExpLv;
        }
        public void GetCoinLv()
        {
            Store.CoinLv = CoinLv;
        }
        public void GetShieldLv()
        {
            Store.ShieldLv = ShieldLv;
        }
        public void GetAtkLv()
        {
            Store.AtkLv = AtkLv;
        }
        public void GetCoin()
        {
            coin = Store.Coin;
        }
        public void GetHead()
        {
            Store.HeadShop = IsHead;
        }
        public void GetGun()
        {
            Store.GunShop = IsGun;
        }
        public void GetArm()
        {
            Store.ArmShop = IsArm;
        }
        public void GetCore()
        {
            Store.CoreShop = IsCore;
        }
        public void GetLeg()
        {
            Store.LegShop = IsLeg;
        }
        public void GetChest()
        {
            Store.ChestShop = IsChest;
        }
        public ShopScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            
            menuTexture = game.Content.Load<Texture2D>("BG_menu");
            Text = game.Content.Load<SpriteFont>("monbar");
            Exit = game.Content.Load<Texture2D>("exit");
            UI = game.Content.Load<Texture2D>("SHOP_UI");
            Item = game.Content.Load<Texture2D>("item");
            Upgrade = game.Content.Load<Texture2D>("Upgrade");
            Symbol = game.Content.Load<Texture2D>("Match");

            HitE = new Rectangle(0, 0, 100, 85);
            HitHead = new Rectangle(10, 160, 150, 150);
            HitGun = new Rectangle(10, 320, 150, 150);
            HitArm = new Rectangle(10, 480, 150, 150);
            HitCore = new Rectangle(180, 160, 150, 150);
            HitLeg = new Rectangle(180, 320, 150, 150);
            HitChest = new Rectangle(180, 480, 150, 150);
            HitH = new Rectangle(400,372,72,72);
            HitAtk = new Rectangle(500, 372, 72, 72);
            HitShield = new Rectangle(600, 372, 72, 72);
            HitCoin = new Rectangle(700, 372, 72, 72);
            HitExp = new Rectangle(800, 372, 72, 72);

            IsHead = false;
            IsGun = false;
            IsArm = false;
            IsCore = false;
            IsLeg = false;
            IsChest = false;
            
            HLv = 1;
            AtkLv = 1;
            ExpLv = 1;
            ShieldLv = 1;
            CoinLv = 1;

            HColor = Color.White;
            AtkColor = Color.White;
            CoinColor = Color.White;
            ShieldColor = Color.White;
            ExpColor = Color.White;

            this.game = game;
        }
        public override void Update(GameTime theTime)
        {

            mouse = Mouse.GetState();
            GetCoin();
            GetHead();
            GetGun();
            GetArm();
            GetCore();
            GetLeg();
            GetChest();
            GetHLv();
            GetAtkLv();
            GetCoinLv();
            GetShieldLv();
            GetExpLv();
            if (HitE.Contains(mouse.X, mouse.Y))
            {
                EColor = Color.Gray;
            }
            else
            {
                EColor = Color.White;
            }
            if (HitE.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && premouse.LeftButton == ButtonState.Released)
            {
                ScreenEvent.Invoke(game.mTitleScreen, new EventArgs());
                return;
            }

            //click
            if(HitHead.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && coin == 5000)
            {
                coin -= 5000;
                GetCoin();
                IsHead = true;
                GetHead();
            }
            if (HitGun.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && coin == 7500)
            {
                coin -= 7500;
                GetCoin();
                IsGun = true;
                GetGun();
            }
            if (HitArm.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && coin == 5000)
            {
                coin -= 5000;
                GetCoin();
                IsArm = true;
                GetArm();
            }
            if (HitCore.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && coin == 7500)
            {
                coin -= 7500;
                GetCoin();
                IsCore = true;
                GetCore();
            }
            if (HitLeg.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && coin == 5000)
            {
                coin -= 5000;
                GetCoin();
                IsLeg = true;
                GetLeg();
            }
            if (HitChest.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && coin == 10000)
            {
                coin -= 10000;
                GetCoin();
                IsChest = true;
                GetChest();
            }
            if (HitH.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && premouse.LeftButton == ButtonState.Released)
            {
                if(HLv < 5)
                {
                    HLv++;
                    GetHLv();
                }
                else if (HLv >= 5)
                {
                    HLv = 5;
                    HColor = Color.Gray;
                    GetHLv();
                }
                else
                {
                    HColor = Color.White;
                }
            }
            if (HitAtk.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && premouse.LeftButton == ButtonState.Released)
            {
                if (AtkLv < 5)
                {
                    AtkLv++;
                    GetHLv();
                }
                else if (AtkLv >= 5)
                {
                    AtkLv = 5;
                    AtkColor = Color.Gray;
                    GetHLv();
                }
                else
                {
                    AtkColor = Color.White;
                }
            }
            if (HitCoin.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && premouse.LeftButton == ButtonState.Released)
            {
                if (CoinLv < 5)
                {
                    CoinLv++;
                    GetHLv();
                }
                else if (CoinLv >= 5)
                {
                    CoinLv = 5;
                    CoinColor = Color.Gray;
                    GetHLv();
                }
                else
                {
                    CoinColor = Color.White;
                }
            }
            if (HitShield.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && premouse.LeftButton == ButtonState.Released)
            {
                if (ShieldLv < 5)
                {
                    ShieldLv++;
                    GetHLv();
                }
                else if (ShieldLv >= 5)
                {
                    ShieldLv = 5;
                    ShieldColor = Color.Gray;
                    GetHLv();
                }
                else
                {
                    ShieldColor = Color.White;
                }
            }
            if (HitExp.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed && premouse.LeftButton == ButtonState.Released)
            {
                if (ExpLv < 5)
                {
                    ExpLv++;
                    GetHLv();
                }
                else if (ExpLv >= 5)
                {
                    ExpLv = 5;
                    ExpColor = Color.Gray;
                    GetHLv();
                }
                else
                {
                    ExpColor = Color.White;
                }
            }

            //Armor
            if (IsHead == true)
            {
                Head = new Rectangle(150, 0, 150, 150);
            }
            else
            {
                Head = new Rectangle(0, 0, 150, 150);
            }
            if (IsGun == true)
            {
                Gun = new Rectangle(150, 150, 150, 150);
            }
            else
            {
                Gun = new Rectangle(0, 150, 150, 150);
            }
            if (IsArm == true)
            {
                Arm = new Rectangle(150, 300, 150, 150);
            }
            else
            {
                Arm = new Rectangle(0, 300, 150, 150);
            }
            if (IsCore == true)
            {
                Core = new Rectangle(150, 450, 150, 150);
            }
            else
            {
                Core = new Rectangle(0, 450, 150, 150);
            }
            if (IsLeg == true)
            {
                Leg = new Rectangle(150, 600, 150, 150);
            }
            else
            {
                Leg = new Rectangle(0, 600, 150, 150);
            }
            if (IsChest == true)
            {
                Chest = new Rectangle(150, 750, 150, 150);
            }
            else
            {
                Chest = new Rectangle(0, 750, 150, 150);
            }

            //Upgrade

            premouse = mouse;
            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            
            theBatch.Draw(menuTexture, Vector2.Zero, Color.White);
            theBatch.Draw(UI, new Vector2(400, 50), Color.White);
            theBatch.DrawString(Text, "coin " + coin.ToString(), new Vector2(180, 100), Color.Red);
            theBatch.Draw(Exit, Vector2.Zero, EColor);
            //armor
            theBatch.Draw(Item, new Vector2(10, 160), Head, Color.White);
            theBatch.Draw(Item, new Vector2(10, 320), Gun, Color.White);
            theBatch.Draw(Item, new Vector2(10, 480), Arm, Color.White);
            theBatch.Draw(Item, new Vector2(180, 160), Core, Color.White);
            theBatch.Draw(Item, new Vector2(180, 320), Leg, Color.White);
            theBatch.Draw(Item, new Vector2(180, 480), Chest, Color.White);
            //Upgrade
            theBatch.Draw(Symbol, new Vector2(400, 300),new Rectangle(0,0,72,72) ,Color.White);
            theBatch.Draw(Upgrade, new Vector2(400, 372), new Rectangle(72*HLv, 18, 72, 72), HColor);

            theBatch.Draw(Symbol, new Vector2(500, 300), new Rectangle(72, 0, 72, 72), Color.White);
            theBatch.Draw(Upgrade, new Vector2(500, 372), new Rectangle(72*AtkLv, 18, 72, 72), AtkColor);

            theBatch.Draw(Symbol, new Vector2(600, 300), new Rectangle(72*2, 0, 72, 72), Color.White);
            theBatch.Draw(Upgrade, new Vector2(600, 372), new Rectangle(72*ShieldLv, 188, 72, 72), ShieldColor);

            theBatch.Draw(Symbol, new Vector2(700, 300), new Rectangle(72*3, 0, 72, 72), Color.White);
            theBatch.Draw(Upgrade, new Vector2(700, 372), new Rectangle(72*CoinLv, 188, 72, 72), CoinColor);

            theBatch.Draw(Symbol, new Vector2(800, 300), new Rectangle(72*4, 0, 72, 72), Color.White);
            theBatch.Draw(Upgrade, new Vector2(800, 372), new Rectangle(72*ExpLv, 188, 72, 72), ExpColor);
            base.Draw(theBatch);
        }
       
    }
}
