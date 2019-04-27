using System.Collections;
using System.Collections.Generic;
using Hourglass.Characters;
using UnityEngine;

namespace Hourglass.Items
{
    public class DebugItem : Item
    {

        public DebugItem(Player user) : base(user)
        {
        }

        public override void UsePrimary()
        {
            throw new System.NotImplementedException();
        }

        public override void UseSecondary()
        {
            throw new System.NotImplementedException();
        }
    }
}