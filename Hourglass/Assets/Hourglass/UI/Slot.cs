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
        private Image image;
        private float minTransparency = 0.3f;
        private float maxTransparency = 0.7f;

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
            image = transform.Find("Item").GetComponent<Image>();
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
                image.enabled = false;
            }
            else
            {
                image.sprite = item.GetSprite();
                image.enabled = true;
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
                if(item.Cooldown() > 0)
                {
                    float cooldownPercent = (item.cooldown - item.Cooldown()) / (item.cooldown);
                    cooldownPercent = (maxTransparency - minTransparency) * cooldownPercent + minTransparency;

                    var tempColor = image.color;
                    tempColor.a = cooldownPercent;
                    image.color = tempColor;
                }
                else
                {
                    var tempColor = image.color;
                    tempColor.a = 1;
                    image.color = tempColor;
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                item = null;
            }
            DisplayItem();
        }
    }
}
