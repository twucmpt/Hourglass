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
        protected Character character;

        private readonly int spriteId;
        protected static double cooldown;
        private double cdtimer;
    
        public static double Price;

        public Item(int id, Character c) {
            spriteId = id;
            character = c;
        }

        public void Update()
        {
            if (cdtimer > 0)
                cdtimer -= Time.deltaTime;
        }

        protected void StartCd(double cd)
        {
            cdtimer = cd;
        }

        protected double Cooldown()
        {
            return cdtimer;
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
