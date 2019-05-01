using Hourglass.Characters;
using Hourglass.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public class ItemProperties
    {

        public readonly string name;
        public readonly Sprite sprite;
        public readonly float price;
        public readonly float cooldown;

        internal ItemProperties(string name, float price, float cooldown, string sprite)
        {
            this.name = name;
            this.sprite = Resources.Load<Sprite>(sprite);
            this.price = price;
            this.cooldown = cooldown;
        }

    }

    public readonly static ItemProperties[] items = new ItemProperties[] {
        //                     Name        Price  Cooldown               Sprite                
         new ItemProperties("DebugTool",    0,      0,  "Images/Items/Default/png/DefaultItem")
        ,new ItemProperties("Teleporter",   25.5f,  14, "Images/Items/Teleporter/png/Teleport")
        ,new ItemProperties("Glider",       10,     3,  "Images/Items/Glider/png/Glider")
        ,new ItemProperties("Pistol",       20f,    1,  "Images/Items/Pistol/png/Pistol")   
        ,new ItemProperties("GrappleHook",  20f,    6,  "Images/Items/GrapplingHook/png/GrapplingHook")

    };

    public static Item GetNewItem(ItemProperties itemProperties, Character c)
    {
        Type t = Type.GetType("Hourglass.Items."+itemProperties.name);
        return (Item)Activator.CreateInstance(t, new object[] {c});
    }


}
