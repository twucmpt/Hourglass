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

        private readonly int spriteId;

        public static double Price;

        public Item(int id, Character c) {
            spriteId = id;
            character = c;
        }

        public Sprite GetSprite()
        {
            return sprites[spriteId];
        }

        public abstract void UsePrimary();
        public abstract void UseSecondary();

        public static readonly Sprite[] sprites = new Sprite[]
        {
            Resources.Load<Sprite>("Images/Items/Default/png/DefaultItem")
        };
    }
}
