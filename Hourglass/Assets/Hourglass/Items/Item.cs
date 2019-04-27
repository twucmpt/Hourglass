using Hourglass.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hourglass.Items
{
    abstract class Item
    {
        Player player;

        public static double Price;

        public Item(Player user) {
            player = user;
        }

        public abstract void UsePrimary();
        public abstract void UseSecondary();
    }
}
