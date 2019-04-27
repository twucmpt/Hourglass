using Hourglass.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hourglass.Items
{
    public abstract class Item
    {
        Character character;

        public static double Price;

        public Item(Character c) {
            character = c;
        }

        public abstract void UsePrimary();
        public abstract void UseSecondary();
    }
}
