using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Items
{
    class Teleporter : Item
    {
        PlayerController player;

        new public static double Price = 25.5;

        public Teleporter(PlayerController user) : base(user) { }

        public override void UsePrimary()
        {
            //must be filled in
        }

        // no secondary ability, do nothing
        public override void UseSecondary()
        { }
    }
}
