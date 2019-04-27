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

        private Item item;

        public void SetItem(Item item)
        {
            this.item = item;
            DisplayItem();
        }

        private void DisplayItem()
        {
            if(item == null)
            {

            }
            else
            {
                transform.Find("Item").GetComponent<Image>().sprite = item.GetSprite();
            }
        }
    }
}
