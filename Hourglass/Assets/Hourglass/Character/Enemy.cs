using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private Character target;

    public void Target(Character t)
    {
        target = t;
    }
}
