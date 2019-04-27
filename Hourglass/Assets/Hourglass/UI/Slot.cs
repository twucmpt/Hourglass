using Hourglass.Characters;
using Hourglass.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hourglass.UI
{
    public class Slot : MonoBehaviour
    {
        public Character character;

        private Item item;

        void Start()
        {
            item = new DebugItem(character);
            DisplayItem();
        }

        public void SetItem(Item item)
        {
            this.item = item;
            DisplayItem();
        }

        private void DisplayItem()
        {
            if(item == null)
            {
                transform.Find("Item").GetComponent<Image>().enabled = false;
            }
            else
            {
                transform.Find("Item").GetComponent<Image>().sprite = item.GetSprite();
                transform.Find("Item").GetComponent<Image>().enabled = true;
            }
        }
    }
}
