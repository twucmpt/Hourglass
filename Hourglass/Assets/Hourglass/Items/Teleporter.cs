﻿using System;
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
        Player player;

        new public static double Price = 25.5;

        public Teleporter(Player user) : base(user) { }

        public override void UsePrimary()
        {
            try
            {
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                player.SetLocation(new Vector2(worldPoint.x, worldPoint.y));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // no secondary ability, do nothing
        public override void UseSecondary()
        { }
    }
}
