﻿using Hourglass.Characters;
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
        Character character;

        protected static Sprite sprite;

        public static double Price;

        public Item(Character c) {
            character = c;
        }

        public Sprite GetSprite()
        {
            return sprite;
        }

        public abstract void UsePrimary();
        public abstract void UseSecondary();
    }
}
