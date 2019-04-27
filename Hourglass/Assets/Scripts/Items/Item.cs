using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Items
{
    abstract class Item
    {
        PlayerController player;

        public static double Price;

        public Item(PlayerController user) {
            player = user;
        }

        public abstract void UsePrimary();
        public abstract void UseSecondary();
    }
}
