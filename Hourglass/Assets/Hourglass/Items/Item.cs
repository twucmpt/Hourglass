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
        private readonly Sprite sprite;
        private readonly float price;
        private readonly float cooldown;

        private double cdtimer;
    
        public Item(int id, Character c) {
            itemId = id;
            character = c;

            sprite = ItemList.items[itemId].sprite;
            price = ItemList.items[itemId].price;
            cooldown = ItemList.items[itemId].cooldown;

        }

        public void Update()
        {
            if (cdtimer > 0)
                cdtimer -= Time.deltaTime;
        }

        protected void StartCooldown()
        {
            cdtimer = cooldown;
        }

        protected double Cooldown()
        {
            return cdtimer;
        }

        public Sprite GetSprite()
        {
            return sprite;
        }

        public abstract void UsePrimary();
        public abstract void UseSecondary();

    }
}
