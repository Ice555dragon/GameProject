using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace GameProject
{
    public static class Store
    {
        public static int Coin { get; set; }
        public static int SelectMc { get; set; }

        public static bool HeadShop { get; set; }
        public static bool GunShop { get; set; }
        public static bool ArmShop { get; set; }
        public static bool CoreShop { get; set; }
        public static bool LegShop { get; set; }
        public static bool ChestShop { get; set; }

        public static int HLv { get; set; }
        public static int AtkLv { get; set; }
        public static int ExpLv { get; set; }
        public static int CoinLv { get; set; }
        public static int ShieldLv { get; set; }
    }
}
