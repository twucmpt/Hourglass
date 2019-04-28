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

        private float cdtimer;
    
        public Item(int id, Character c) {
            itemId = id;
            character = c;

        }

        public void Update()
        {
            if (cdtimer > 0)
                cdtimer -= Time.deltaTime;
        }

        protected void StartCooldown()
        {
            cdtimer = CooldownCost;
        }

        public float Cooldown()
        {
            return cdtimer;
        }

        public float CooldownCost
        {
            get
            {
                return ItemList.items[itemId].cooldown;
            }
        }

        public float Price
        {
            get
            {
                return ItemList.items[itemId].price;
            }
        }

        public Sprite Sprite
        {
            get
            {
                return ItemList.items[itemId].sprite;
            }
        }

        public abstract void UsePrimary();
        public abstract void UseSecondary();

    }
}
