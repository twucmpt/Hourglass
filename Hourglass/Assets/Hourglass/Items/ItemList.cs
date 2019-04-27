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

        internal ItemProperties(string name, string sprite, float price, float cooldown)
        {
            this.name = name;
            this.sprite = Resources.Load<Sprite>(sprite);
            this.price = price;
            this.cooldown = cooldown;
        }

    }

    public readonly static ItemProperties[] items = new ItemProperties[] {
        new ItemProperties("DebugTool","Images/Items/Default/png/DefaultItem",0,0),
        new ItemProperties("Teleporter","Images/Items/Default/png/DefaultItem",25.5f,14)
    };


}
