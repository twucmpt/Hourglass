using Hourglass.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Hourglass.Items
{
    public abstract class Item
    {
        protected Character character;

        private readonly int itemId;

        public Item(int id, Character c) {
            itemId = id;
            character = c;
        }

        public Sprite GetSprite()
        {
            return sprites[itemId];
        }

        public float GetPrice()
        {
            return prices[itemId];
        }

        public abstract void UsePrimary();
        public abstract void UseSecondary();




        public static readonly Sprite[] sprites = new Sprite[]
        {
            Resources.Load<Sprite>("Images/Items/Default/png/DefaultItem"),
            Resources.Load<Sprite>("Images/Items/Default/png/DefaultItem")
        };

        public static readonly float[] prices = new float[]
        {
            0,
            25.5f
        };
    }
}
