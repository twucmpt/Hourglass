using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using Hourglass.Characters;

namespace Hourglass.Items
{
    class Teleporter : Item
    {
        new public static double Price = 25.5;
        new protected static double cooldown = 14;

        public Teleporter(Player user) : base(0, user) { }

        public override void UsePrimary()
        {
            if (Cooldown() > 0) return;

            try
            {
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                character.SetLocation(new Vector2(worldPoint.x, worldPoint.y));

                StartCooldown();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // no secondary ability, do nothing
        public override void UseSecondary() {}

        public override void OnEquip() {}
        public override void UsePassive() {}
        public override void OnDequip() {}

    }
}
