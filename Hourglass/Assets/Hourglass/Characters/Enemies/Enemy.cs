﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hourglass.Characters
{
    public class Enemy : NPC
    {
        protected new void Start()
        {
            base.Start();
            Target(manager.player);
        }
    }
}