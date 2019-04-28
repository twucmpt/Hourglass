using System.Collections;
using System.Collections.Generic;
using Hourglass.Characters;
using UnityEngine;

namespace Hourglass.Items
{
    public class DebugItem : Item
    {

        public DebugItem(Character user) : base(0, user) {}

        public override void UsePrimary() {}

        public override void UseSecondary() {}

        public override void ActivatePassive() {}
        public override void UsePassive() {}
        public override void RevertPassive() {}
    }
}