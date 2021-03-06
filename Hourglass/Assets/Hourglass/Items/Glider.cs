﻿using System.Collections;
using System.Collections.Generic;
using Hourglass.Characters;
using UnityEngine;

namespace Hourglass.Items
{
    public class Glider : Item
    {

        public float fallModifier = 0.5f;
        public float horizontalModifier = 3f;
        private bool horiztonalModified = false;

        public Glider(Character user) : base(2, user) { }

        public override void UsePrimary() { }

        public override void UseSecondary() { }

        private void ActivateHorizontal()
        {
            horiztonalModified = true;
            character.controller.horizontalModifier = character.controller.horizontalModifier * horizontalModifier;
            character.controller.useNormals = false;
        }
        private void RevertHorizontal()
        {
            horiztonalModified = false;
            character.controller.horizontalModifier = character.controller.horizontalModifier / horizontalModifier;
            character.controller.useNormals = true;
        }

        public override void OnEquip() {
            character.controller.fallModifier = character.controller.fallModifier * fallModifier;

        }
        public override void UsePassive()
        {
            if(character.IsGrounded() && horiztonalModified)
            {
                RevertHorizontal();
            }
            else if(!character.IsGrounded() && !horiztonalModified)
            {
                ActivateHorizontal();
            }

            if(horiztonalModified)
            {
                if (character.controller.facingRight)
                {
                    character.controller.MoveOverride(1);
                }
                else
                {
                    character.controller.MoveOverride(-1);
                }
            }
        }
        public override void OnDequip()
        {
            character.controller.fallModifier = character.controller.fallModifier / fallModifier;
            if(horiztonalModified)
            {
                RevertHorizontal();
            }
        }
    }
}