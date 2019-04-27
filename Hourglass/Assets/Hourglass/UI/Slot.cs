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

        private static Sprite active;
        private static Sprite inactive;

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
            active = Resources.Load<Sprite>("Images/UI/png/quickslot_selected");
            inactive = Resources.Load<Sprite>("Images/UI/png/quickslot");
            UpdateSlot();
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

        internal void SetActive(bool active)
        {
            if (active) {
                GetComponent<Image>().sprite = Slot.active;
            }
            else
            {
                GetComponent<Image>().sprite = Slot.inactive;
            }
        }

        public void UpdateSlot()
        {
            try
            {
                item = character.GetItem(id);
            }
            catch(ArgumentOutOfRangeException e)
            {
                item = null;
            }
            DisplayItem();
        }
    }
}
