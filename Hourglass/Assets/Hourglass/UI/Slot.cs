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

        private Character character;
        private String key;
        private int id;
        private Item item;

        public void Setup(Character character, int id, String key)
        {
            this.character = character;
            this.key = key;
            this.id = id;
            transform.Find("Key").GetComponent<Text>().text = key;
        }

        void Start()
        {
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

        public void UpdateSlot()
        {
            item = character.GetItem(id);
            DisplayItem();
        }
    }
}
