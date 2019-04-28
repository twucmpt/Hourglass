﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hourglass.Characters
{
    public class Enemy : NPC
    {
        protected void Start()
        {
            Target(manager.player);
        }

        protected override void Interact(Character target)
        {
            Attack(target);
        }
    }
}